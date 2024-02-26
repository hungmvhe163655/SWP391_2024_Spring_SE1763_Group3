using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class HomeManagerConfiguration : IEntityTypeConfiguration<HomeManager>
    {
        public void Configure(EntityTypeBuilder<HomeManager> builder)
        {
            // A hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            builder.HasData(
                new HomeManager
                {
                    Id = "3F2504E0-4F89-41D3-9A0C-0305E82C3301",
                    FullName = "Anh Tuấn",
                    PhoneNumber = "0551234567",
                    PasswordHash = hasher.HashPassword(null, "password789"),
                    Email = "anh_tuan@example.com",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    IsMale = true,
                    PortraitPictureUrl = "",
                },
                new HomeManager
                {
                    Id = "3F2504E0-4F89-41D3-9A0C-0305E82C3302",
                    FullName = "Bích Hằng",
                    PhoneNumber = "0659876543",
                    PasswordHash = hasher.HashPassword(null, "passwordabc"),
                    Email = "bich_hang@example.com",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    IsMale = false,
                    PortraitPictureUrl = "",
                },
                new HomeManager
                {
                    Id = "3F2504E0-4F89-41D3-9A0C-0305E82C3306",
                    FullName = "Lâm Trường",
                    PhoneNumber = "0852227890",
                    PasswordHash = hasher.HashPassword(null, "password456"),
                    Email = "lam_truong@example.com",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = true,
                    IsMale = true,
                    PortraitPictureUrl = "",
                },
                new HomeManager
                {
                    Id = "3F2504E0-4F89-41D3-9A0C-0305E82C3307",
                    FullName = "Linh Châu",
                    PhoneNumber = "0955556789",
                    PasswordHash = hasher.HashPassword(null, "password789"),
                    Email = "linh_chau@example.com",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    IsMale = false,
                    PortraitPictureUrl = "",
                },
                new HomeManager
                {
                    Id = "3F2504E0-4F89-41D3-9A0C-0305E82C3309",
                    FullName = "Quỳnh Như",
                    PhoneNumber = "0955555678",
                    PasswordHash = hasher.HashPassword(null, "password456"),
                    Email = "quynh_nhu@example.com",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    IsMale = false,
                    PortraitPictureUrl = "",
                },
                new HomeManager
                {
                    Id = "3F2504E0-4F89-41D3-9A0C-0305E82C3310",
                    FullName = "Hoàng Sơn",
                    PhoneNumber = "0955559012",
                    PasswordHash = hasher.HashPassword(null, "password789"),
                    Email = "hoang_son@example.com",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    IsMale = true,
                    PortraitPictureUrl = "",
                });
        }
    }
}
