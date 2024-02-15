using Entities.Base;
using System.ComponentModel.DataAnnotations;
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

namespace Entities.Models
{
    public class Contract : IEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime ExpectedCheckOutDate { get; set; }
        public DateTime? RealCheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int NumberOfTenants { get; set; }

        [Column(TypeName = "money")]
        public decimal Deposit { get; set; }

        [StringLength(500)]
        public string Note { get; set; } = null!;

        // One Room
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; } = null!;

        // One Tenant
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; } = null!;

        // One Tenant
        public Guid HomeManagerId { get; set; }
        public virtual HomeManager HomeManager { get; set; } = null!;
    }
}
