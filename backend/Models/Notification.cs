using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Notification, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Notification send to many Tenants.
 * One Notification is made by one Home Manager.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // One Home Manager
        public Guid HomeMangerId { get; set; }
        public HomeManager HomeManager { get; set; }

        // Many Tenants
        public ICollection<Tenant> Tenants { get; set; }
    }
}
