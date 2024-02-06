using Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Apartment, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Room is in one Building.
 * One Room has many Contracts.
 * One Room has many Bills.
 * One Room has many Tenants.
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class Room : IEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string RoomNo { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // One Building 
        public Guid BuildingId { get; set; }
        public virtual Building Building { get; set; } = null!;

        // Many Contracts
        public virtual ICollection<Contract> Contracts { get; set; } = null!;

        // Many Bills
        public virtual ICollection<Bill> Bills { get; set; } = null!;

        // Many Tenants
        public virtual ICollection<Tenant> Tenants { get; set; } = null!;
    }
}
