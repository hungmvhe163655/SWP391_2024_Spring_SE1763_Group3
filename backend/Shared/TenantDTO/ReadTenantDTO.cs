namespace Shared.TenantDTO
{
    public record ReadTenantDTO
    (
        string Id,
        string FullName,
        string UserName,
        string PhoneNumber,
        bool PhoneNumberConfirmed,
        string PasswordHash,
        bool IsMale,
        string Email,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        DateTime? DeletedAt,
        bool EmailConfirmed,
        int AccessFailedCount,
        string PortraitPictureUrl,
        DateTime Dob,
        string Address,
        Guid? RoomId
    );
}
