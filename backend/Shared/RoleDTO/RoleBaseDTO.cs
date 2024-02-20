using System.ComponentModel.DataAnnotations;

namespace Shared.RoleDTO
{
    public abstract record RoleBaseDTO
    {
        [Required(ErrorMessage = "Role name is required")]
        [MaxLength(255, ErrorMessage = "Maximum length for the Name is 255 characters.")]
        public string Name { get; init; }
    }
}