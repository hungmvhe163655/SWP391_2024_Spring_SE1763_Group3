using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Building Service, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Building Service has many Buildings. 
 * One Building Service on many Bills. 
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class BuildingService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal PricePerMonth { get; set; }

        // One Building
        public Guid BuildingId { get; set; }
        public virtual Building Building { get; set; } = null!;
    }
}
