using Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.RoomDTO
{
    public class UpdateRoomDTO
    {
        public Guid Id { get; set; }
        public string RoomNo { get; set; }
        public string Size { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        // One Building 
        public int BuildingId { get; set; }
        
      
        
    }
}
