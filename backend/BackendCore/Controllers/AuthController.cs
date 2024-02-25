using BackendCore.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace BackendCore.Controllers
{
    public record AuthenticationInfo
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; init; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(3, ErrorMessage = "Password must be at least 3 characters long")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Password is 100 characters.")]
        public string Password { get; init; } = null!;
    }

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public AuthController(HomeManagementDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] AuthenticationInfo info)
        //{
        //    // Find user by email
        //    var user = await _context.Tenants.FirstOrDefaultAsync(u => u.Email == info.Email);

        //    if (user == null)
        //    {
        //        return Unauthorized("Tenant not found");
        //    }

        //    // Verify password
        //    if (user.Password != info.Password)
        //    {
        //        return Unauthorized("Invalid password");
        //    }

        //    return Ok(user);
        //}
    }


}
