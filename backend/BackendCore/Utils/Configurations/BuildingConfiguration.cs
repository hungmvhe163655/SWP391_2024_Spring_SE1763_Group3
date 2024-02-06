using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasData(
                new Building
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303"),
                    Name = "Chung cư An Nhiên",
                    Address = "123 Đường Chính",
                    Description = "Đây là mô tả mẫu cho tòa nhà.",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    WaterPricePerMonth = 21000.0m,
                    ElectricityPricePerMonth = 2675.0m,
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3301")
                },
                new Building
                {
                    Id = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304"),
                    Name = "Chung cư mini Lạc Quân",
                    Address = "456 Đường Phong",
                    Description = "Mô tả khác cho tòa nhà.",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    WaterPricePerMonth = 22000.0m,
                    ElectricityPricePerMonth = 2500.0m,
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3301")
                },
                new Building
                {
                    Id = Guid.Parse("5F2504E0-4F89-41D3-9A0C-0305E82C3305"),
                    Name = "Tòa nhà 68",
                    Address = "789 Đường Sồi",
                    Description = "Mô tả khác cho tòa nhà.",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    WaterPricePerMonth = 15000.0m,
                    ElectricityPricePerMonth = 2700.0m,
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3302")
                },
                new Building
                {
                    Id = Guid.Parse("9F2504E0-4F89-41D3-9A0C-0305E82C3309"),
                    Name = "Chung cư mini 102",
                    Address = "1617 Đường Thông",
                    Description = "Mô tả cho tòa nhà.",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    WaterPricePerMonth = 27000.0m,
                    ElectricityPricePerMonth = 3500.0m,
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3307")
                },
                new Building
                {
                    Id = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312"),
                    Name = "Trọ Vũ Bạch",
                    Address = "2223 Đường Vũ Bạch",
                    Description = "Mô tả cho tòa nhà.",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    WaterPricePerMonth = 20000.0m,
                    ElectricityPricePerMonth = 3400.0m,
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3310")
                });
        }
    }
}
