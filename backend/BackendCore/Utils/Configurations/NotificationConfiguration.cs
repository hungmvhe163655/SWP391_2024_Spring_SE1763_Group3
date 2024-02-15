using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasData(
                new Notification
                {
                    Id = Guid.Parse("74F47318-9D30-47F0-9D6B-623C60ACD9E7"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    IsReaded = true,
                    Message = "Đóng tiền nhà tháng 12/2023",
                    TenantId = Guid.Parse("B4E6EA80-F066-44F4-AA55-30E0A0FE30AF")
                },
                new Notification
                {
                    Id = Guid.Parse("ACDF8315-A60B-469D-90EB-E450EBB1526C"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    IsReaded = false,
                    Message = "Đóng tiền nhà tháng 12/2023",
                    TenantId = Guid.Parse("F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F")
                },
                new Notification
                {
                    Id = Guid.Parse("8088BF14-7543-4D5F-BB03-891998318B87"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    IsReaded = false,
                    Message = "Đóng tiền nhà tháng 12/2023",
                    TenantId = Guid.Parse("257862CB-BFD1-4D55-AB50-10D186E3E8F4")
                });
        }
    }
}
