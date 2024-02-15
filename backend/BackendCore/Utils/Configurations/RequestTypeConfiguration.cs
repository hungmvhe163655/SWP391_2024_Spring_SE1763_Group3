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
                    Type = "Câu hỏi"
                },
                new RequestType()
                {
                    Id = 2,
                    Type = "Phàn nàn"
                },
                new RequestType()
                {
                    Id = 3,
                    Type = "Yêu cầu"
                },
                new RequestType()
                {
                    Id = 4,
                    Type = "Đề xuất"
                },
                new RequestType()
                {
                    Id = 5,
                    Type = "Khác"
                });
        }
    }
}
