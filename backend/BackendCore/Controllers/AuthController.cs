using AutoMapper;
using BackendCore.Services.InternalServices.Contracts;
using BackendCore.Utils.ActionFilters;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.AuthenticationDTO;

namespace BackendCore.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<BuildingResident> _userManager;
        private readonly IAuthenticationService _service;

        public AuthController(IMapper mapper, UserManager<BuildingResident> userManager, IAuthenticationService service)
        {
            _mapper = mapper;
            _userManager = userManager;
            _service = service;
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromBody] TenantRegistrationDTO tenantRegistration)
        {
            var (isValid, message) = await _service.ValidateRegisterUser(tenantRegistration);

            if (!isValid)
                return Unauthorized(new
                {
                    Message = message
                });

            var user = _mapper.Map<Tenant>(tenantRegistration);

            user.CreatedAt = DateTime.Now;

            var result = await _userManager.CreateAsync(user, tenantRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, tenantRegistration.Roles);

            return StatusCode(201, new
            {
                Message = "Register successfully!"
            });
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginDTO)
        {
            var (isValid, message, user) = await _service.ValidateUser(loginDTO);

            if (!isValid || user is null)
                return Unauthorized(new
                {
                    Message = message
                });

            var userId = await _userManager.GetUserIdAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            return Ok(new
            {
                UserId = userId,
                UserRoles = userRoles,
                Token = await _service.CreateToken(true)
            });
        }
    }


}
