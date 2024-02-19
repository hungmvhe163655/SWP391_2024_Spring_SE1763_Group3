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
        public string Name { get; init; }

        public decimal PricePerMonth { get; init; }

        public Guid? BuildingId { get; init; }
    }
}
