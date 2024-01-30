/**
 * Class for Building, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Building have many Rooms.
 * One Building have many Building Services.
 * One Building have many News.
 * One Building have one Home Manager.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // One Home Manager
        public Guid HomeManagerId { get; set; }
        public HomeManager HomeManager { get; set; }

        // Many Rooms
        public ICollection<Room> Rooms { get; set; }

        // Many Building Services
        public ICollection<BuildingService> BuildingServices { get; set; }

        // Many News
        public ICollection<News> News { get; set; }
    }
}
