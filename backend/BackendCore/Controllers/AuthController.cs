using AutoMapper;
using BackendCore.Services.InternalServices.Contracts;
using BackendCore.Utils;
using BackendCore.Utils.ActionFilters;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.AuthenticationDTO;
using System.ComponentModel.DataAnnotations;


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
            var user = _mapper.Map<Tenant>(tenantRegistration);

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
                Token = await _service.CreateToken(true)
            });
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO user)
        {
            var (isValid, message) = await _service.ValidateUser(user);

            if (!isValid)
                return Unauthorized(message);

            return Ok(new
            {
                Token = await _service.CreateToken(true)
            });
        }
    }


}
