using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for News, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One News is authored by one Home Manager.
 * One News for many Buildings.
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(255)]
        public string Title { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        // One Home Manager
        public Guid HomeManagerId { get; set; }
        public virtual HomeManager HomeManager { get; set; } = null!;

        // Many Buildings
        public virtual ICollection<Building> Buildings { get; set; } = null!;
    }
}
