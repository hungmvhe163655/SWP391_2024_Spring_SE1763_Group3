using System.ComponentModel.DataAnnotations;

namespace Shared.AuthenticationDTO
{
    public record TenantRegistrationDTO : RegistrationBaseDTO
    {
        public DateTime Dob { get; set; }

        [MaxLength(500)]
        public string Address { get; set; } = null!;
    }
}
