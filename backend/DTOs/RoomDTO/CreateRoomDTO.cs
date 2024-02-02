using Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.RoomDTO
{
    public class CreateRoomDTO
    {
        public string RoomNo { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public int BuildingId { get; set; }

    }
}
