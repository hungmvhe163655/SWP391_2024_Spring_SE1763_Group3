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
        private readonly UserManager<Tenant> _userManager;
        private readonly IAuthenticationService _service;

        public AuthController(IMapper mapper, UserManager<Tenant> userManager, IAuthenticationService service)
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
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO user)
        {
            var (isValid, message) = await _service.ValidateUser(user);

            if (!isValid)
                return Unauthorized(new
                {
                    Message = message
                });

            return Ok(new
            {
                Token = await _service.CreateToken(true)
            });
        }
    }


}
