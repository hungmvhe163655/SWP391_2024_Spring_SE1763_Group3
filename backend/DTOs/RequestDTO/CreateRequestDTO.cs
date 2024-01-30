using Backend.Models;

namespace Backend.DTOs.RequestDTO
{
    public class CreateRequestDTO
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Guid TenantId { get; set; }

        public Guid HomeManagerId { get; set; }

        public int RequestTypeId { get; set; }

        public int RequestStatusId { get; set; }
    }
}
