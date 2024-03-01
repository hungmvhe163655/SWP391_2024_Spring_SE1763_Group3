using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestStatusDTO
{
    public abstract record RequestStatusBaseDTO
    {
        [Required(ErrorMessage = "Status is required")]
        [MinLength(8, ErrorMessage = "Status must be at least 8 characters long")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Status is 100 characters.")]
        public string Status { get; init; }

        [Range(1, 3, ErrorMessage = "Role Id is not valid")]
        public int RoleId { get; init; }

        public string PortraitPictureUrl { get; init; }

        public Guid? RoomId { get; init; }
    }
}
