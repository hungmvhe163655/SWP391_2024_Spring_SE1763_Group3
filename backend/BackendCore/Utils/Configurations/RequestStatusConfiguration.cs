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
                    Status = "Sent",
                },
                new RequestStatus()
                {
                    Id = 2,
                    Status = "Pending",
                },
                new RequestStatus()
                {
                    Id = 3,
                    Status = "Accepted",
                },
                new RequestStatus()
                {
                    Id = 4,
                    Status = "Rejected",
                });
        }
    }
}
