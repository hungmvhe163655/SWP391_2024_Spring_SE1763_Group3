using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-8A0C-0305E82C3303"),
                    RoomNo = "101",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-7A0C-0305E82C3303"),
                    RoomNo = "102",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-6A0C-0305E82C3303"),
                    RoomNo = "103",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-5A0C-0305E82C3303"),
                    RoomNo = "104",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-4A0C-0305E82C3303"),
                    RoomNo = "105",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-31D3-5A0C-0305E82C3303"),
                    RoomNo = "106",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-3A0C-0305E82C3303"),
                    RoomNo = "107",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-360C-0305E82C3303"),
                    RoomNo = "108",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-350C-0305E82C3303"),
                    RoomNo = "109",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("4F2504E0-4F89-41D3-351C-0305E82C3303"),
                    RoomNo = "110",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("4F2504E0-4F89-41D3-9A0C-0305E82C3303")
                },
                new Room
                {
                    Id = Guid.Parse("99524668-BF7B-43FC-A198-37A66478C8E5"),
                    RoomNo = "201",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("8EB065EE-C50C-4A7E-AC97-6C795E6C02A2"),
                    RoomNo = "202",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("AF339181-931C-4F9A-AA6A-06646AA77A75"),
                    RoomNo = "203",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("3B4B679B-9C20-4C1A-8407-0B7D7BFF797E"),
                    RoomNo = "204",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("31652927-66B2-4CF0-8C88-6B1A10563AEB"),
                    RoomNo = "205",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("72F654F5-AEB6-410E-B5E9-51328ACB04E6"),
                    RoomNo = "206",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("62CAA73A-47CB-4B48-AACA-4052C0FDFB2E"),
                    RoomNo = "207",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("CBF552C9-BBFB-4920-9F43-9782C33D88E8"),
                    RoomNo = "208",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("28894308-5DB2-4C90-99AD-45F9379A989B"),
                    RoomNo = "209",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("3F907BFA-CB32-4804-81F6-395B301F262E"),
                    RoomNo = "210",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("2F2504E0-4F89-41D3-9A0C-0305E82C3304")
                },
                new Room
                {
                    Id = Guid.Parse("C4939B2E-D7D9-41C9-83EA-E9557FD22F26"),
                    RoomNo = "210",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("5F2504E0-4F89-41D3-9A0C-0305E82C3305")
                },
                new Room
                {
                    Id = Guid.Parse("DB740CEC-F865-455B-874E-AA8E3436115F"),
                    RoomNo = "211",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("5F2504E0-4F89-41D3-9A0C-0305E82C3305")
                },
                new Room
                {
                    Id = Guid.Parse("82BC05BA-6175-4452-AB6C-F168C25D58E1"),
                    RoomNo = "212",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("5F2504E0-4F89-41D3-9A0C-0305E82C3305")
                },
                new Room
                {
                    Id = Guid.Parse("8F4700C0-BFDC-48B6-8BFA-BB0BF12F5C7D"),
                    RoomNo = "213",
                    Price = 2000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("5F2504E0-4F89-41D3-9A0C-0305E82C3305")
                },
                new Room
                {
                    Id = Guid.Parse("A61FEE38-6669-4F35-AA9A-2589C09E28BF"),
                    RoomNo = "200",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("9F2504E0-4F89-41D3-9A0C-0305E82C3309")
                },
                new Room
                {
                    Id = Guid.Parse("C717D609-50CA-4427-89A0-555B7D75FB80"),
                    RoomNo = "201",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("9F2504E0-4F89-41D3-9A0C-0305E82C3309")
                },
                new Room
                {
                    Id = Guid.Parse("5DEE6FD4-2989-4268-968A-BD8AAA7099DB"),
                    RoomNo = "202",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("9F2504E0-4F89-41D3-9A0C-0305E82C3309")
                },
                new Room
                {
                    Id = Guid.Parse("0C55994E-91AA-4AB1-BBC2-B845AA2078FB"),
                    RoomNo = "203",
                    Price = 4000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("9F2504E0-4F89-41D3-9A0C-0305E82C3309")
                },
                new Room
                {
                    Id = Guid.Parse("BE270FD3-7488-4BD2-AC23-C36C898ECF66"),
                    RoomNo = "401A",
                    Price = 5000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312")
                },
                new Room
                {
                    Id = Guid.Parse("8D1B5B5E-3C68-4A3B-BECE-0544C71590B2"),
                    RoomNo = "402A",
                    Price = 5000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312")
                },
                new Room
                {
                    Id = Guid.Parse("4BC0FA1C-39CC-44C7-9E67-334706BEF121"),
                    RoomNo = "403A",
                    Price = 5000000.0m,
                    IsDeleted = false,
                    BuildingId = Guid.Parse("CF2504E0-4F89-41D3-9A0C-0305E82C3312")
                }
            );
        }
    }
}
