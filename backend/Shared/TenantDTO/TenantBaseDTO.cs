using System.ComponentModel.DataAnnotations;

namespace Shared.TenantDTO
{
    public abstract record TenantBaseDTO
    {
        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(255, ErrorMessage = "Maximum length for the Name is 255 characters.")]
        public string FullName { get; init; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; init; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Password is 100 characters.")]
        public string Password { get; init; }

        [Required(ErrorMessage = "Gender is required")]
        public bool IsMale { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; init; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime Dob { get; init; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(500, ErrorMessage = "Maximum length for the Address is 500 characters.")]
        public string Address { get; init; }

        [Range(1, 3, ErrorMessage = "Role Id is not valid")]
        public int RoleId { get; init; }

        public DateTime CreatedAt { get; init; }

        public DateTime? UpdatedAt { get; init; }

        public bool IsDeleted { get; init; }

        public DateTime? DeletedAt { get; init; }

        public string PortraitPictureUrl { get; init; }

        public Guid? RoomId { get; init; }
    }
}
