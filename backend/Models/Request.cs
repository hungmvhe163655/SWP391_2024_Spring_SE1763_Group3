#nullable disable
namespace Backend.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int RequestTypeId {  get; set; }
        public int RequestStatusId { get; set; }
        public Guid TenantId { get; set; }   
        public Guid HomeManagerId { get; set; }
        public Tenant Tenant { get; set; }  
        public HomeManager HomeManager { get; set; }  
        public RequestType RequestType { get; set; }    
        public RequestStatus RequestStatus { get; set; }   
    }
}
