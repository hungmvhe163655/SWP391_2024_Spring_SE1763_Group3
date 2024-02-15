using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendCore.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousWaterReading = table.Column<int>(type: "int", nullable: false),
                    CurrentWaterReading = table.Column<int>(type: "int", nullable: false),
                    PreviousElectricityReading = table.Column<int>(type: "int", nullable: false),
                    CurrentElectricityReading = table.Column<int>(type: "int", nullable: false),
                    WaterPricePerMonth = table.Column<decimal>(type: "money", nullable: false),
                    ElectricityPricePerMonth = table.Column<decimal>(type: "money", nullable: false),
                    RoomRentPrice = table.Column<decimal>(type: "money", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillStatusId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_BillStatuses_BillStatusId",
                        column: x => x.BillStatusId,
                        principalTable: "BillStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuildingNews",
                columns: table => new
                {
                    BuildingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingNews", x => new { x.BuildingsId, x.NewsId });
                });

            migrationBuilder.CreateTable(
                name: "BuildingResidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PortraitPictureUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingResidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingResidents_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaterPricePerMonth = table.Column<decimal>(type: "money", nullable: false),
                    ElectricityPricePerMonth = table.Column<decimal>(type: "money", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingResidents_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    HomeManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_BuildingResidents_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_BuildingResidents_TenantId",
                        column: x => x.TenantId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_BuildingResidents_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_BuildingResidents_TenantId",
                        column: x => x.TenantId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuildingServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PricePerMonth = table.Column<decimal>(type: "money", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingServices_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfTenants = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<decimal>(type: "money", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_BuildingResidents_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_BuildingResidents_TenantId",
                        column: x => x.TenantId,
                        principalTable: "BuildingResidents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BillStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Chưa trả" },
                    { 2, "Đã trả" },
                    { 3, "Quá hạn" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Chưa nhận" },
                    { 2, "Đã nhận" },
                    { 3, "Chấp nhận" },
                    { 4, "Từ chối" }
                });

            migrationBuilder.InsertData(
                table: "RequestTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Câu hỏi" },
                    { 2, "Phàn nàn" },
                    { 3, "Yêu cầu" },
                    { 4, "Đề xuất" },
                    { 5, "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Home Manager" },
                    { 3, "Tenant" }
                });

            migrationBuilder.InsertData(
                table: "BuildingResidents",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Discriminator", "Email", "FullName", "IsDeleted", "IsMale", "Password", "PhoneNumber", "PortraitPictureUrl", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "anh_tuan@example.com", "Anh Tuấn", false, true, "password789", "0551234567", "", 2, null },
                    { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3302"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "bich_hang@example.com", "Bích Hằng", false, false, "passwordabc", "0659876543", "", 2, null },
                    { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3306"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "lam_truong@example.com", "Lâm Trường", true, true, "password456", "0852227890", "", 2, null },
                    { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3307"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "linh_chau@example.com", "Linh Châu", false, false, "password789", "0955556789", "", 2, null },
                    { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3309"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "quynh_nhu@example.com", "Quỳnh Như", false, false, "password456", "0955555678", "", 2, null },
                    { new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3310"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "hoang_son@example.com", "Hoàng Sơn", false, true, "password789", "0955559012", "", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "Description", "ElectricityPricePerMonth", "HomeManagerId", "IsDeleted", "Name", "UpdatedAt", "WaterPricePerMonth" },
                values: new object[,]
                {
                    { new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), "456 Đường Phong", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả khác cho tòa nhà.", 2500.0m, new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), false, "Chung cư mini Lạc Quân", null, 22000.0m },
                    { new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), "123 Đường Chính", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Đây là mô tả mẫu cho tòa nhà.", 2675.0m, new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), false, "Chung cư An Nhiên", null, 21000.0m },
                    { new Guid("5f2504e0-4f89-41d3-9a0c-0305e82c3305"), "789 Đường Sồi", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả khác cho tòa nhà.", 2700.0m, new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3302"), false, "Tòa nhà 68", null, 15000.0m },
                    { new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), "1617 Đường Thông", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả cho tòa nhà.", 3500.0m, new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3307"), false, "Chung cư mini 102", null, 27000.0m },
                    { new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "2223 Đường Vũ Bạch", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả cho tòa nhà.", 3400.0m, new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3310"), false, "Trọ Vũ Bạch", null, 20000.0m }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "Description", "HomeManagerId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0b447141-a4eb-4444-9d6a-d35ba9693995"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3306"), "Đóng tiền điện nước tháng 12/2023", null },
                    { new Guid("2a9306b5-7c9d-4cda-82c7-94c7641de97e"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3302"), "Đóng tiền nhà tháng 1/2024", null },
                    { new Guid("68d0f123-4855-4004-bdf2-aeebae8f7bde"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), "Đóng tiền điện nước tháng 12/2023", null }
                });

            migrationBuilder.InsertData(
                table: "BuildingServices",
                columns: new[] { "Id", "BuildingId", "Name", "PricePerMonth" },
                values: new object[,]
                {
                    { new Guid("8f696d6a-034b-41af-949a-969f78935a22"), new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), "Tiền thang máy", 20000m },
                    { new Guid("9b9d671f-7196-49d2-9fe7-d439aa2dac3a"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "Tiền xe", 50000m },
                    { new Guid("c1690607-068b-47df-973d-7babb3efc1e8"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "Tiền máy giặt", 100000m },
                    { new Guid("f5610f03-3992-428c-8c45-d31309c72799"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "Tiền rác", 20000m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "DeletedAt", "IsDeleted", "Price", "RoomNo" },
                values: new object[,]
                {
                    { new Guid("0c55994e-91aa-4ab1-bbc2-b845aa2078fb"), new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), null, false, 4000000.0m, "203" },
                    { new Guid("28894308-5db2-4c90-99ad-45f9379a989b"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "209" },
                    { new Guid("31652927-66b2-4cf0-8c88-6b1a10563aeb"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "205" },
                    { new Guid("3b4b679b-9c20-4c1a-8407-0b7d7bff797e"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "204" },
                    { new Guid("3f907bfa-cb32-4804-81f6-395b301f262e"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "210" },
                    { new Guid("4bc0fa1c-39cc-44c7-9e67-334706bef121"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), null, false, 5000000.0m, "403A" },
                    { new Guid("4f2504e0-4f89-31d3-5a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "106" },
                    { new Guid("4f2504e0-4f89-41d3-350c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "109" },
                    { new Guid("4f2504e0-4f89-41d3-351c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "110" },
                    { new Guid("4f2504e0-4f89-41d3-360c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "108" },
                    { new Guid("4f2504e0-4f89-41d3-3a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "107" },
                    { new Guid("4f2504e0-4f89-41d3-4a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "105" },
                    { new Guid("4f2504e0-4f89-41d3-5a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "104" },
                    { new Guid("4f2504e0-4f89-41d3-6a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "103" },
                    { new Guid("4f2504e0-4f89-41d3-7a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "102" },
                    { new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), null, false, 4000000.0m, "101" },
                    { new Guid("5dee6fd4-2989-4268-968a-bd8aaa7099db"), new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), null, false, 4000000.0m, "202" },
                    { new Guid("62caa73a-47cb-4b48-aaca-4052c0fdfb2e"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "207" },
                    { new Guid("72f654f5-aeb6-410e-b5e9-51328acb04e6"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "206" },
                    { new Guid("82bc05ba-6175-4452-ab6c-f168c25d58e1"), new Guid("5f2504e0-4f89-41d3-9a0c-0305e82c3305"), null, false, 2000000.0m, "212" },
                    { new Guid("8d1b5b5e-3c68-4a3b-bece-0544c71590b2"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), null, false, 5000000.0m, "402A" },
                    { new Guid("8eb065ee-c50c-4a7e-ac97-6c795e6c02a2"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "202" },
                    { new Guid("8f4700c0-bfdc-48b6-8bfa-bb0bf12f5c7d"), new Guid("5f2504e0-4f89-41d3-9a0c-0305e82c3305"), null, false, 2000000.0m, "213" },
                    { new Guid("99524668-bf7b-43fc-a198-37a66478c8e5"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "201" },
                    { new Guid("a61fee38-6669-4f35-aa9a-2589c09e28bf"), new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), null, false, 4000000.0m, "200" },
                    { new Guid("af339181-931c-4f9a-aa6a-06646aa77a75"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "203" },
                    { new Guid("be270fd3-7488-4bd2-ac23-c36c898ecf66"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), null, false, 5000000.0m, "401A" },
                    { new Guid("c4939b2e-d7d9-41c9-83ea-e9557fd22f26"), new Guid("5f2504e0-4f89-41d3-9a0c-0305e82c3305"), null, false, 2000000.0m, "210" },
                    { new Guid("c717d609-50ca-4427-89a0-555b7d75fb80"), new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), null, false, 4000000.0m, "201" },
                    { new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), null, false, 2000000.0m, "208" },
                    { new Guid("db740cec-f865-455b-874e-aa8e3436115f"), new Guid("5f2504e0-4f89-41d3-9a0c-0305e82c3305"), null, false, 2000000.0m, "211" }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "BillStatusId", "DeletedAt", "Description", "IsDeleted", "RoomId" },
                values: new object[] { new Guid("bfa7b59f-ba4d-4ddc-bfe4-49884dd0bd80"), 1, null, "", false, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303") });

            migrationBuilder.InsertData(
                table: "BuildingResidents",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "Discriminator", "Dob", "Email", "FullName", "IsDeleted", "IsMale", "Password", "PhoneNumber", "PortraitPictureUrl", "RoleId", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("257862cb-bfd1-4d55-ab50-10d186e3e8f4"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "yen123@example.com", "Vũ Hoàng Yến", false, false, "mk123", "0965432109", "", 3, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), null },
                    { new Guid("4f9038f6-dcfd-40d4-96ed-601686db6b11"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1986, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ptb@example.com", "Phạm Thị B", false, false, "mk123", "0943210987", "", 3, new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), null },
                    { new Guid("86f1e1d1-5ab7-48d3-8b14-97b0ad42018e"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1989, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "tte@example.com", "Trần Thị E", false, false, "mk123", "0910987654", "", 3, new Guid("db740cec-f865-455b-874e-aa8e3436115f"), null },
                    { new Guid("a1e1f042-ab4a-431e-8a8e-710e2eceffc3"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1985, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "tva@example.com", "Trần Văn A", false, true, "mk123", "0954321098", "", 3, new Guid("4f2504e0-4f89-41d3-7a0c-0305e82c3303"), null },
                    { new Guid("b4e6ea80-f066-44f4-aa55-30e0a0fe30af"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1990, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email1@example.com", "Nguyễn Thị Linh", false, false, "mk123", "0987654321", "", 3, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), null },
                    { new Guid("d7fbd8c3-8d8a-4dbb-be44-34b9d9c6d012"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1987, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "lvc@example.com", "Phạm Thị C", false, false, "mk123", "0932109876", "", 3, new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), null },
                    { new Guid("f63c6963-7a41-4ab5-ad8e-4fef8a8a843f"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1991, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "hyen4132@example.com", "Hoàng Thị Yến", false, false, "mk123", "0976543210", "", 3, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), null },
                    { new Guid("ff4d981f-e335-4928-9f2c-db378e6afc5b"), "", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1988, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ntd@example.com", "Nguyễn Thị D", false, false, "mk123", "0921098765", "", 3, new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), null }
                });

            migrationBuilder.InsertData(
                table: "BillDetails",
                columns: new[] { "Id", "BillId", "CreatedAt", "CurrentElectricityReading", "CurrentWaterReading", "ElectricityPricePerMonth", "PreviousElectricityReading", "PreviousWaterReading", "RoomRentPrice", "UpdatedAt", "WaterPricePerMonth" },
                values: new object[] { new Guid("fd5aabe7-f87b-4d27-9896-91a1ef83a91e"), new Guid("bfa7b59f-ba4d-4ddc-bfe4-49884dd0bd80"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1161, 120, 3200m, 1030, 100, 4000000m, null, 15000m });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "CheckInDate", "CreatedAt", "DeletedAt", "Deposit", "ExpectedCheckOutDate", "HomeManagerId", "IsDeleted", "Note", "NumberOfTenants", "RealCheckOutDate", "RoomId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08be2e31-4abb-446c-8b22-d25d140aa0d7"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), false, "", 3, null, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), new Guid("b4e6ea80-f066-44f4-aa55-30e0a0fe30af"), null },
                    { new Guid("40c3a2c4-dede-4722-be95-48a67c45f552"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), false, "", 2, null, new Guid("4f2504e0-4f89-41d3-7a0c-0305e82c3303"), new Guid("a1e1f042-ab4a-431e-8a8e-710e2eceffc3"), null },
                    { new Guid("417a93ea-bc60-4c30-a4c1-d3b856889b08"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3302"), false, "", 1, null, new Guid("db740cec-f865-455b-874e-aa8e3436115f"), new Guid("86f1e1d1-5ab7-48d3-8b14-97b0ad42018e"), null },
                    { new Guid("df9af346-6a2e-4930-ad39-5480c984eff9"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), false, "", 3, null, new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), new Guid("4f9038f6-dcfd-40d4-96ed-601686db6b11"), null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsReaded", "Message", "TenantId" },
                values: new object[,]
                {
                    { new Guid("74f47318-9d30-47f0-9d6b-623c60acd9e7"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Đóng tiền nhà tháng 12/2023", new Guid("b4e6ea80-f066-44f4-aa55-30e0a0fe30af") },
                    { new Guid("8088bf14-7543-4d5f-bb03-891998318b87"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Đóng tiền nhà tháng 12/2023", new Guid("257862cb-bfd1-4d55-ab50-10d186e3e8f4") },
                    { new Guid("acdf8315-a60b-469d-90eb-e450ebb1526c"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Đóng tiền nhà tháng 12/2023", new Guid("f63c6963-7a41-4ab5-ad8e-4fef8a8a843f") }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "HomeManagerId", "IsDeleted", "RequestStatusId", "RequestTypeId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9d387606-2a10-4119-b5a5-16176626de19"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Có điều khiển điều hòa không?", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3306"), false, 3, 1, new Guid("257862cb-bfd1-4d55-ab50-10d186e3e8f4"), null },
                    { new Guid("ba9f1f1a-46ad-4ebd-a5e3-f26daae31812"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm bình nóng lạnh", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3306"), false, 2, 4, new Guid("f63c6963-7a41-4ab5-ad8e-4fef8a8a843f"), null },
                    { new Guid("f9d7aac9-6978-4b71-b6ab-f56ac147f8b3"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Không có nước", new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301"), false, 1, 2, new Guid("b4e6ea80-f066-44f4-aa55-30e0a0fe30af"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillStatusId",
                table: "Bills",
                column: "BillStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RoomId",
                table: "Bills",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingNews_NewsId",
                table: "BuildingNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingResidents_RoleId",
                table: "BuildingResidents",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingResidents_RoomId",
                table: "BuildingResidents",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_HomeManagerId",
                table: "Buildings",
                column: "HomeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingServices_BuildingId",
                table: "BuildingServices",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_HomeManagerId",
                table: "Contracts",
                column: "HomeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RoomId",
                table: "Contracts",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TenantId",
                table: "Contracts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_News_HomeManagerId",
                table: "News",
                column: "HomeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TenantId",
                table: "Notifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_HomeManagerId",
                table: "Requests",
                column: "HomeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TenantId",
                table: "Requests",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_BillId",
                table: "BillDetails",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Rooms_RoomId",
                table: "Bills",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingNews_Buildings_BuildingsId",
                table: "BuildingNews",
                column: "BuildingsId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingNews_News_NewsId",
                table: "BuildingNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingResidents_Rooms_RoomId",
                table: "BuildingResidents",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingResidents_Rooms_RoomId",
                table: "BuildingResidents");

            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "BuildingNews");

            migrationBuilder.DropTable(
                name: "BuildingServices")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BuildingServicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "RequestStatuses");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "BillStatuses");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "BuildingResidents");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
