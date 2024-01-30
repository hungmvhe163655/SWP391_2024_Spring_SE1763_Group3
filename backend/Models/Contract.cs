using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Contract, this is use for entity framework to generate database.
 * This class is represent for a table in database. 
 * 
 * One Contract has one Room.
 * One Contract has one Tenant.
 * 
 * <p>ExpectedCheckOutDate is fix checkout date in contract, 
 * if tenant checkout before this, tenant will loose deposit</p>
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Contract
    {
        public Guid Id { get; set; }              
        public DateTime CheckInDate { get; set; }
        public DateTime ExpectedCheckOutDate { get; set; }
        public DateTime? RealCheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "money")]
        public decimal Deposit { get; set; }

        // One Room
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        // One Tenant
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
