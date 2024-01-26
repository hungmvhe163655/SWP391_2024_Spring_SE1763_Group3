/**
 * Class for Bill, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<RoomService> RoomServices { get; set; }
    }
}
