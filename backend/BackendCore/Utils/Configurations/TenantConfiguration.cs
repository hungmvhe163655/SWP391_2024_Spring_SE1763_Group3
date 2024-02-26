using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            // A hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            builder.HasData(
                new Tenant
                {
                    Id = "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF",
                    FullName = "Nguyễn Thị Linh",
                    PhoneNumber = "0987654321",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "email1@example.com",
                    UserName = "linh123",
                    NormalizedUserName = "LINH123",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1990-11-01"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-8A0C-0305E82C3303")
                },
                new Tenant
                {
                    Id = "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F",
                    FullName = "Hoàng Thị Yến",
                    PhoneNumber = "0976543210",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "hyen4132@example.com",
                    UserName = "hyen4132",
                    NormalizedUserName = "HYEN4132",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1991-02-02"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-8A0C-0305E82C3303")
                },
                new Tenant
                {
                    Id = "257862CB-BFD1-4D55-AB50-10D186E3E8F4",
                    FullName = "Vũ Hoàng Yến",
                    PhoneNumber = "0965432109",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "yen123@example.com",
                    UserName = "yen123",
                    NormalizedUserName = "YEN123",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1992-03-03"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-8A0C-0305E82C3303")
                },
                new Tenant
                {
                    Id = "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3",
                    FullName = "Trần Văn A",
                    PhoneNumber = "0954321098",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "tva@example.com",
                    UserName = "tva",
                    NormalizedUserName = "TVA",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1985-04-04"),
                    Address = "",
                    IsMale = true,
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-7A0C-0305E82C3303")
                },
                new Tenant
                {
                    Id = "4F9038F6-DCFD-40D4-96ED-601686DB6B11",
                    FullName = "Phạm Thị B",
                    PhoneNumber = "0943210987",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "ptb@example.com",
                    UserName = "ptb",
                    NormalizedUserName = "PTB",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1986-05-05"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("CBF552C9-BBFB-4920-9F43-9782C33D88E8")
                },
                new Tenant
                {
                    Id = "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012",
                    FullName = "Phạm Thị C",
                    PhoneNumber = "0932109876",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "lvc@example.com",
                    UserName = "lvc",
                    NormalizedUserName = "LVC",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1987-06-06"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("CBF552C9-BBFB-4920-9F43-9782C33D88E8")
                },
                new Tenant
                {
                    Id = "FF4D981F-E335-4928-9F2C-DB378E6AFC5B",
                    FullName = "Nguyễn Thị D",
                    PhoneNumber = "0921098765",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "ntd@example.com",
                    UserName = "ntd",
                    NormalizedUserName = "NTD",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1988-07-07"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("CBF552C9-BBFB-4920-9F43-9782C33D88E8")
                },
                new Tenant
                {
                    Id = "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E",
                    FullName = "Trần Thị E",
                    PhoneNumber = "0910987654",
                    PasswordHash = hasher.HashPassword(null, "mk123"),
                    Email = "tte@example.com",
                    UserName = "tte",
                    NormalizedUserName = "TTE",
                    CreatedAt = DateTime.Parse("2024-05-02"),
                    UpdatedAt = null,
                    IsDeleted = false,
                    PortraitPictureUrl = "",
                    Dob = DateTime.Parse("1989-08-08"),
                    Address = "",
                    IsMale = false,
                    RoomId = Guid.Parse("DB740CEC-F865-455B-874E-AA8E3436115F")
                });
        }
    }
}