namespace Shared.NotificationDTO
{
    public record ReadNotificationDTO
    (
        Guid Id,
        DateTime CreatedAt,
        bool IsReaded,
        string Message,
        Guid TenantId
    );
}
