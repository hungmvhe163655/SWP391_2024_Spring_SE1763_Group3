using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
    {
        public void Configure(EntityTypeBuilder<RequestStatus> builder)
        {
            builder.HasData(
                new RequestStatus()
                {
                    Id = 1,
                    Status = "Chưa nhận",
                },
                new RequestStatus()
                {
                    Id = 2,
                    Status = "Đã nhận",
                },
                new RequestStatus()
                {
                    Id = 3,
                    Status = "Chấp nhận",
                },
                new RequestStatus()
                {
                    Id = 4,
                    Status = "Từ chối",
                });
        }
    }
}
