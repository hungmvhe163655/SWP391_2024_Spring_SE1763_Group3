using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.BuildingServiceDTO
{
    public class CreateBuildingServiceDTO
    {
        public string Name { get; set; }
        
        public decimal Money { get; set; }
    }
}
