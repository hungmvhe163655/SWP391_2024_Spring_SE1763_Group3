using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
