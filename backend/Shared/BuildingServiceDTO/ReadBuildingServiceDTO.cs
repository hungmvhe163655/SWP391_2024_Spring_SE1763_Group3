using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BuildingServiceDTO
{
    public record ReadBuildingServiceDTO
    (   Guid Id,
        string FullName,
        decimal PricePerMonth,
        Guid BuildingId
    );
}
