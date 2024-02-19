using System.ComponentModel.DataAnnotations;

namespace Shared.ContractDTO
{
    public abstract record ContractBaseDTO
    {
        [Required(ErrorMessage = "Check-in date is required")]
        public DateTime CheckInDate { get; init; }

        [Required(ErrorMessage = "Expected check-out date is required")]
        public DateTime ExpectedCheckOutDate { get; init; }

        [Required(ErrorMessage = "Number of tenants is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of tenants must be greater or equal than 0")]
        public int NumberOfTenants { get; init; }

        [Required(ErrorMessage = "Deposit is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Deposit must be greater than or equal to 0")]
        public decimal Deposit { get; init; }

        [StringLength(500, ErrorMessage = "Note can contain up to 500 characters")]
        public string Note { get; init; }

        [Required(ErrorMessage = "Room ID is required")]
        public Guid RoomId { get; init; }

        [Required(ErrorMessage = "Tenant ID is required")]
        public Guid TenantId { get; init; }

        [Required(ErrorMessage = "Home manager ID is required")]
        public Guid HomeManagerId { get; init; }
    }
}
