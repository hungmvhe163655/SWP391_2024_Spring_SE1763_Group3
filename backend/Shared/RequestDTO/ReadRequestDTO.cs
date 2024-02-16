using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestDTO
{
    public record ReadRequestDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid TenantId { get; set; }
        public string TenantName { get; set; }
        public Guid HomeManagerId { get; set; }
        public string HomeManagerName { get; set; }
        public int RequestTypeId { get; set; }
        public string RequestType { get; set; }
        public int RequestStatusId { get; set; }
        public string RequestStatus { get; set; }
    }
}
