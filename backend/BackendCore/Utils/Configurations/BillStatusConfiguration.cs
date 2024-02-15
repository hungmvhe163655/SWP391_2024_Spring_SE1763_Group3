using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class BillStatusConfiguration : IEntityTypeConfiguration<BillStatus>
    {
        public void Configure(EntityTypeBuilder<BillStatus> builder)
        {
            builder.HasData(
                new BillStatus()
                {
                    Id = 1,
                    Status = "Chưa trả",
                },
                new BillStatus()
                {
                    Id = 2,
                    Status = "Đã trả",
                },
                new BillStatus()
                {
                    Id = 3,
                    Status = "Quá hạn",
                });
        }
    }
}
