using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.TenantDTO
{
    public record ReadTenantDTO
    (
        Guid Id,
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
