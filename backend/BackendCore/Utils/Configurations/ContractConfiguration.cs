using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.HasData(
                new Contract
                {
                    Id = Guid.Parse("08BE2E31-4ABB-446C-8B22-D25D140AA0D7"),
                    CheckInDate = DateTime.Parse("2024-05-02"),
                    ExpectedCheckOutDate = DateTime.Parse("2025-05-02"),
                    RealCheckOutDate = null,
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    NumberOfTenants = 3,
                    Deposit = 3000000,
                    Note = "",
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-8A0C-0305E82C3303"),
                    TenantId = "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3301"
                },
                new Contract
                {
                    Id = Guid.Parse("40C3A2C4-DEDE-4722-BE95-48A67C45F552"),
                    CheckInDate = DateTime.Parse("2024-05-02"),
                    ExpectedCheckOutDate = DateTime.Parse("2025-05-02"),
                    RealCheckOutDate = null,
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    NumberOfTenants = 2,
                    Deposit = 3000000,
                    Note = "",
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-7A0C-0305E82C3303"),
                    TenantId = "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3301"
                },
                new Contract
                {
                    Id = Guid.Parse("DF9AF346-6A2E-4930-AD39-5480C984EFF9"),
                    CheckInDate = DateTime.Parse("2024-05-02"),
                    ExpectedCheckOutDate = DateTime.Parse("2025-05-02"),
                    RealCheckOutDate = null,
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    NumberOfTenants = 3,
                    Deposit = 3000000,
                    Note = "",
                    RoomId = Guid.Parse("CBF552C9-BBFB-4920-9F43-9782C33D88E8"),
                    TenantId = "4F9038F6-DCFD-40D4-96ED-601686DB6B11",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3301"
                },
                new Contract
                {
                    Id = Guid.Parse("417A93EA-BC60-4C30-A4C1-D3B856889B08"),
                    CheckInDate = DateTime.Parse("2024-05-02"),
                    ExpectedCheckOutDate = DateTime.Parse("2025-05-02"),
                    RealCheckOutDate = null,
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    NumberOfTenants = 1,
                    Deposit = 3000000,
                    Note = "",
                    RoomId = Guid.Parse("DB740CEC-F865-455B-874E-AA8E3436115F"),
                    TenantId = "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3302"
                });
        }
    }
}
