#nullable disable
namespace Backend.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int RequestTypeId {  get; set; }
        public int RequestStatusId { get; set; }
        public int TenantId { get; set; }   
        public int HouseManagerId { get; set; }
        public Tenant Tenant { get; set; }  
        public HouseManager HouseManager { get; set; }  
        public RequestType RequestType { get; set; }    
        public RequestStatus RequestStatus { get; set; }   
    }
}
