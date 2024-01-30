/**
 * Class for Request Status, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * Request Status has many Requests.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        // Many Requests
        public ICollection<Request> Requests { get; set; }
    }
}
