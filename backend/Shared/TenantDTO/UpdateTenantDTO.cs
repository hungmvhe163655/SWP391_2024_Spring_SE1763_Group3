using System.ComponentModel.DataAnnotations;

namespace Shared.TenantDTO
{
    public record UpdateTenantDTO : TenantBaseDTO
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; init; }
        [Required(ErrorMessage = "Address is required")]
        [MaxLength(500, ErrorMessage = "Maximum length for the Address is 500 characters.")]
        public string Address { get; init; }
    }
}
