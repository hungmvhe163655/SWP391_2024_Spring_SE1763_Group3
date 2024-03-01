using BackendCore.Services.InternalServices.Contracts;
using BackendCore.Utils.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Shared.AuthenticationDTO;

namespace BackendCore.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public TokenController(IAuthenticationService service) => _service = service;

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await
            _service.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
