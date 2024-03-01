using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class BuildingServiceConfiguration : IEntityTypeConfiguration<BuildingService>
    {
        public void Configure(EntityTypeBuilder<BuildingService> builder)
        {
            // Allow Temporal table for Building Service
            // table, is used to tracked history
            builder.ToTable("BuildingServices", bs => bs.IsTemporal());


            builder.HasData(
                new BuildingService
                {
                    Id = Guid.Parse("C1690607-068B-47DF-973D-7BABB3EFC1E8"),
                    Name = "Laundry Fee",
                    PricePerMonth = 100000,
                    BuildingId = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312")
                },
                new BuildingService
                {
                    Id = Guid.Parse("9B9D671F-7196-49D2-9FE7-D439AA2DAC3A"),
                    Name = "Parking Fee",
                    PricePerMonth = 50000,
                    BuildingId = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312")
                },
                new BuildingService
                {
                    Id = Guid.Parse("F5610F03-3992-428C-8C45-D31309C72799"),
                    Name = "Trash Fee",
                    PricePerMonth = 20000,
                    BuildingId = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312")
                },
                new BuildingService
                {
                    Id = Guid.Parse("8F696D6A-034B-41AF-949A-969F78935A22"),
                    Name = "Elevator Fee",
                    PricePerMonth = 20000,
                    BuildingId = Guid.Parse("9F2504E0-4F89-41D3-9A0C-0305E82C3309")
                });
        }
    }
}
