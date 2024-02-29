using Entities.Models;
using Shared.AuthenticationDTO;

namespace BackendCore.Services.InternalServices.Contracts
{
    public interface IAuthenticationService
    {
        Task<(bool, string)> ValidateUser(LoginDTO user);
        Task<(bool, string)> ValidateRegisterUser(RegistrationBaseDTO user);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);

    }
}
