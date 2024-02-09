﻿namespace Shared.TenantDTO
{
    public record CreateTenantDTO
    (
        string FullName,
        string PhoneNumber,
        string Password,
        bool IsMale,
        string Email,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        DateTime? DeletedAt,
        string PortraitPictureUrl,
        int RoleId,
        DateTime Dob,
        string Address,
        Guid? RoomId
    );
}
