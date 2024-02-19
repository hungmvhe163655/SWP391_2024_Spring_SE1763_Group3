using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BuildingServiceDTO
{
    public record BuildingServiceBaseDTO  
    {
        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(255, ErrorMessage = "Maximum length for the Name is 255 characters.")]
        public string FullName { get; init; }


        [Range(1, 3, ErrorMessage = "Role Id is not valid")]
        public int RoleId { get; init; }

        public bool IsDeleted { get; init; }

        public Guid? RoomId { get; init; }
    }
}
