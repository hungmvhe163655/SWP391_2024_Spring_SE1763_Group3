using System.ComponentModel.DataAnnotations;

namespace Shared.AuthenticationDTO
{
    public abstract record RegistrationBaseDTO
    {
        public string FullName { get; init; }
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
        public bool IsMale { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public ICollection<string>  Roles { get; init; }

    }
}
