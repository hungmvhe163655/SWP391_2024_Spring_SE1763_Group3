/**
 * Class for Bill, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Bill has many Utility Costs.
 * One Bill for one Room only.
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

        // One Room 
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        // Many Utility Costs
        public ICollection<UtilityCost> UtilityCosts { get; set; }
    }
}
