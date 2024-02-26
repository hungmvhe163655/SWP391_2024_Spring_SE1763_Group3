using Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Request, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Request has One Request Type
 * One Request has One Tenant
 * One Request has One Request Status
 * One Request has One Home Manager
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class Request : IEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // One Tenant
        public string TenantId { get; set; } = null!;
        public virtual Tenant Tenant { get; set; } = null!;

        // One Home Manager
        public string HomeManagerId { get; set; } = null!;
        public virtual HomeManager HomeManager { get; set; } = null!;

        // One Request
        public int RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; } = null!;

        // One Request Status
        public int RequestStatusId { get; set; }
        public virtual RequestStatus RequestStatus { get; set; } = null!;
    }
}
