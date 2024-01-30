/**
 * Class for Request Type, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * Request Type has many Requests.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class RequestType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
