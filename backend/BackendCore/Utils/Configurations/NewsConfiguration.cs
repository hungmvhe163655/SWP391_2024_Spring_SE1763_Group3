using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasData(
                new News
                {
                    Id = Guid.Parse("68D0F123-4855-4004-BDF2-AEEBAE8F7BDE"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    Title = "Đóng tiền điện nước tháng 12/2023",
                    Description = "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3301"
                },
                new News
                {
                    Id = Guid.Parse("2A9306B5-7C9D-4CDA-82C7-94C7641DE97E"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    Title = "Đóng tiền nhà tháng 1/2024",
                    Description = "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3302"
                },
                new News
                {
                    Id = Guid.Parse("0B447141-A4EB-4444-9D6A-D35BA9693995"),
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    Title = "Đóng tiền điện nước tháng 12/2023",
                    Description = "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.",
                    HomeManagerId = "3F2504E0-4F89-41D3-9A0C-0305E82C3306"
                });
        }
    }
}
