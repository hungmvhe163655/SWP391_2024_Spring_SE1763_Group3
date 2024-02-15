using System.ComponentModel.DataAnnotations;

/**
 * Class for Request Type, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * Request Type has many Requests.
 * 
 * @author PhuVD
 */

namespace Entities.Models
{
    public class RequestType
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Type { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; } = null!;
    }
}
