/**
 * Class for Tenant, this is use for entity framework to generate database.
 * This class NOT represent for a table in database. This class represent Inheritence
 * in both Database and in Class using Table per Hierarchy (TPH).
 * 
 * Tenant has many Contracts.
 * Tenant has many Requests.
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
