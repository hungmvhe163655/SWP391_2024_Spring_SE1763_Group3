using Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.ContractDTO
{
    public class UpdateContractDTO
    {
        public Guid Id { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? ExpectedCheckOutDate { get; set; }
        public decimal? Deposit { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
