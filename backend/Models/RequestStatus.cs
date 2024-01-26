#nullable disable
namespace Backend.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
