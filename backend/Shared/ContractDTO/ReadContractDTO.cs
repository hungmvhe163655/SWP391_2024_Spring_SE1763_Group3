namespace Shared.ContractDTO
{
    public record ReadContractDTO
    (
        Guid Id,
        DateTime CheckInDate,
        DateTime ExpectedCheckOutDate,
        DateTime? RealCheckOutDate,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        DateTime? DeletedAt,
        int NumberOfTenants,
        decimal Deposit,
        string Note,
        Guid RoomId,
        Guid TenantId,
        Guid HomeManagerId
    );
}
