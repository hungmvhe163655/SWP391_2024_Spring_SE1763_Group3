using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.HasData(
                new Request
                {
                    Id = Guid.Parse("F9D7AAC9-6978-4B71-B6AB-F56AC147F8B3"),
                    Description = "Không có nước",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    TenantId = Guid.Parse("B4E6EA80-F066-44F4-AA55-30E0A0FE30AF"),
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3301"),
                    RequestTypeId = 2,
                    RequestStatusId = 1
                },
                new Request
                {
                    Id = Guid.Parse("BA9F1F1A-46AD-4EBD-A5E3-F26DAAE31812"),
                    Description = "Thêm bình nóng lạnh",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    TenantId = Guid.Parse("F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F"),
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3306"),
                    RequestTypeId = 4,
                    RequestStatusId = 2
                },
                new Request
                {
                    Id = Guid.Parse("9D387606-2A10-4119-B5A5-16176626DE19"),
                    Description = "Có điều khiển điều hòa không?",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    TenantId = Guid.Parse("257862CB-BFD1-4D55-AB50-10D186E3E8F4"),
                    HomeManagerId = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3306"),
                    RequestTypeId = 1,
                    RequestStatusId = 3
                });
        }
    }
}
