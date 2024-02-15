using Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Building, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Building have many Rooms.
 * One Building have many Building Services.
 * One Building have many News.
 * One Building have one Home Manager.
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class Building : IEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(500)]
        public string Address { get; set; } = null!;
        [MaxLength(1000)]
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Column(TypeName = "money")]
        public decimal WaterPricePerMonth { get; set; }
        [Column(TypeName = "money")]
        public decimal ElectricityPricePerMonth { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // One Home Manager
        public Guid HomeManagerId { get; set; }
        public virtual HomeManager HomeManager { get; set; } = null!;

        // Many Rooms
        public virtual ICollection<Room> Rooms { get; set; } = null!;

        // Many Building Services
        public virtual ICollection<BuildingService> BuildingServices { get; set; } = null!;

        // Many News
        public virtual ICollection<News> News { get; set; } = null!;
    }
}
