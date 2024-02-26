using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class RequestTypeConfiguration : IEntityTypeConfiguration<RequestType>
    {
        public void Configure(EntityTypeBuilder<RequestType> builder)
        {
            builder.HasData(
                new RequestType()
                {
                    Id = 1,
                    Type = "Question"
                },
                new RequestType()
                {
                    Id = 2,
                    Type = "Complain"
                },
                new RequestType()
                {
                    Id = 3,
                    Type = "Request"
                },
                new RequestType()
                {
                    Id = 4,
                    Type = "Suggestion"
                },
                new RequestType()
                {
                    Id = 5,
                    Type = "Others"
                });
        }
    }
}
