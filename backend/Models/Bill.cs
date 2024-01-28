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
        public Guid Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int BillStatusId { get; set; }
        public BillStatus BillStatus { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<UtilityCost> UtilityCosts { get; set; }
    }
}
