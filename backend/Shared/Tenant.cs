using System.ComponentModel.DataAnnotations;

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

namespace Entities.Models
{
    public class Tenant : BuildingResident
    {
        public DateTime Dob { get; set; }

        [MaxLength(500)]
        public string Address { get; set; } = null!;

        public Guid? RoomId { get; set; }
        public virtual Room? Room { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; } = null!;
        public virtual ICollection<Request> Requests { get; set; } = null!;
        public virtual ICollection<Notification> Notifications { get; set; } = null!;
    }
}
