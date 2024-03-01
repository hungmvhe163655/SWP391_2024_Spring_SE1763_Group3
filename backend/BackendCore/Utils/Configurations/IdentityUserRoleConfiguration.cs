using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCore.Utils.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "257862CB-BFD1-4D55-AB50-10D186E3E8F4"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "4F9038F6-DCFD-40D4-96ED-601686DB6B11"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "FF4D981F-E335-4928-9F2C-DB378E6AFC5B"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "3F2504E0-4F89-41D3-9A0C-0305E82C3301"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "3F2504E0-4F89-41D3-9A0C-0305E82C3302"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "3F2504E0-4F89-41D3-9A0C-0305E82C3306"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "3F2504E0-4F89-41D3-9A0C-0305E82C3307"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "3F2504E0-4F89-41D3-9A0C-0305E82C3309"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-583d56fd7210",
                UserId = "3F2504E0-4F89-41D3-9A0C-0305E82C3310"
            });
        }
    }
}
