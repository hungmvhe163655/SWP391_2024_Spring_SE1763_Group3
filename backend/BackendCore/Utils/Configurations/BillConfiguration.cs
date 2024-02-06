using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasData(
                new Bill
                {
                    Id = Guid.Parse("BFA7B59F-BA4D-4DDC-BFE4-49884DD0BD80"),
                    Description = "",
                    IsDeleted = false,
                    BillStatusId = 1,
                    RoomId = Guid.Parse("4F2504E0-4F89-41D3-8A0C-0305E82C3303")
                });
        }
    }
}
