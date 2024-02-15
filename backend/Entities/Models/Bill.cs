using Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Bill, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Bill has many Utility Costs.
 * One Bill for one Room only.
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class Bill : IEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // One Status
        public int BillStatusId { get; set; }
        public virtual BillStatus BillStatus { get; set; } = null!;

        // One Room 
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; } = null!;

        public virtual BillDetail BillDetail { get; set; } = null!;
    }
}
