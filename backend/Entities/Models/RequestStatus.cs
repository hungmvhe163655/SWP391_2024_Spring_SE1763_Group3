using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;

/**
 * Class for Request Status, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * Request Status has many Requests.
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class RequestStatus
    {
        public Guid? Id { get; set; }

        [MaxLength(255)]
        public string Status { get; set; } = null!;

        // Many Requests
        public virtual ICollection<Contract> Contracts { get; set; } = null!;
        public virtual ICollection<Request> Requests { get; set; } = null!;
        public virtual ICollection<Notification> Notifications { get; set; } = null!;

    }
}



