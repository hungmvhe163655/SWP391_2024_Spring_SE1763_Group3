/**
 * Class for Tenant, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * Tenant has many bills.
 * Tenant has many contracts.
 *
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Tenant : BuildingResident
    {
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
