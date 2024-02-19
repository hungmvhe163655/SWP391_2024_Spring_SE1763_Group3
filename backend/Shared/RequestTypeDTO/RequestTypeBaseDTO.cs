using System.ComponentModel.DataAnnotations;

namespace Shared.RequestTypeDTO
{
    public abstract record RequestTypeBaseDTO
    {
        [Required(ErrorMessage = "Type is required")]
        [MinLength(4, ErrorMessage = "Type must be at least 4 characters long")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Type is 100 characters.")]
        public string Type { get; init; }

        /*[Range(1, 3, ErrorMessage = "Role Id is not valid")]
        public int RoleId { get; init; }*/

        public string PortraitPictureUrl { get; init; }

        public Guid? RoomId { get; init; }
    }
}

