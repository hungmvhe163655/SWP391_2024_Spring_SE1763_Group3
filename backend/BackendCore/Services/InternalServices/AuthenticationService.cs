using BackendCore.Services.InternalServices.Contracts;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.AuthenticationDTO;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackendCore.Services.InternalServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<BuildingResident> _userManager;
        private readonly IOptions<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly ILoggerManager _logger;
        private BuildingResident? _user;

        public AuthenticationService(ILoggerManager logger,
            UserManager<BuildingResident> userManager, IOptions<JwtConfiguration> configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;
        }

        public async Task<(bool, string)> ValidateUser(LoginDTO user)
        {
            try
            {
                _user = await _userManager.FindByEmailAsync(user.Email);

                if (_user == null)
                {
                    _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Email '{user.Email}' not found.");
                    return (false, $"Email '{user.Email}' not found.");
                }

                var result = await _userManager.CheckPasswordAsync(_user, user.Password);

                if (!result)
                {
                    _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed for user '{user.Email}'. Incorrect password.");
                    return (false, "Incorrect password.");
                }

                return (true, "Authentication successful.");

            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(ValidateUser)}: An error occurred while validating user '{user.Email}'. {ex.Message}");
                throw; // Rethrow the exception for centralized exception handling
            }
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity!.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();
            _user = user;

            return await CreateToken(populateExp: false);
        }


        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user!.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(accessToken, refreshToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secrete!.ToCharArray())),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Secrete!.ToCharArray());
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, _user!.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
            List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

    }
}
