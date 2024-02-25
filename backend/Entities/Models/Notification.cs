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

namespace Entities.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsReaded { get; set; }

        [MaxLength(255)]
        public string Message { get; set; } = null!;

        // One Tenant
        public string TenantId { get; set; } = null!;
        public virtual Tenant Tenant { get; set; } = null!;
    }
}
