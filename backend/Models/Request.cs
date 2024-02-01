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

#nullable disable
namespace Backend.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // One Tenant
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        // One Home Manager
        public Guid HomeManagerId { get; set; }
        public HomeManager HomeManager { get; set; }

        // One Request
        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }

        // One Request Status
        public int RequestStatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
