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
