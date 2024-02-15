using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasData(
                new BillDetail
                {
                    Id = Guid.Parse("FD5AABE7-F87B-4D27-9896-91A1EF83A91E"),
                    BillId = Guid.Parse("BFA7B59F-BA4D-4DDC-BFE4-49884DD0BD80"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    PreviousWaterReading = 100,
                    CurrentWaterReading = 120,
                    PreviousElectricityReading = 1030,
                    CurrentElectricityReading = 1161,
                    WaterPricePerMonth = 15000,
                    ElectricityPricePerMonth = 3200,
                    RoomRentPrice = 4000000
                }); ;
        }
    }
}
