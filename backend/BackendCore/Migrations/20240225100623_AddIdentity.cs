using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendCore.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PortraitPictureUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    HomeManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_AspNetUsers_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "AspNetUsers",
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
                    HomeManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "AspNetUsers",
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
                    TenantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
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
                    TenantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomeManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AspNetUsers",
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
                name: "BuildingNews",
                columns: table => new
                {
                    BuildingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingNews", x => new { x.BuildingsId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_BuildingNews_Buildings_BuildingsId",
                        column: x => x.BuildingsId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuildingNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_Bills_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
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
                    TenantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomeManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "f37016d3-5406-46bf-a45c-411b0580d72b", "Administrator", "ADMINISTRATOR" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "25881f61-aad4-41c6-9407-d01d06d66e40", "Tenant", "TENANT" },
                    { "2c5e174e-3b0e-446f-86af-683d56fd7210", "ddf50698-f1c7-466f-a504-407286fb514c", "Home Manager", "HOME MAANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Discriminator", "Email", "EmailConfirmed", "FullName", "IsDeleted", "IsMale", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PortraitPictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "3F2504E0-4F89-41D3-9A0C-0305E82C3301", 0, "fd7811be-7672-48b3-8656-ce4c51bcf07e", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "anh_tuan@example.com", false, "Anh Tuấn", false, true, false, null, null, null, "AQAAAAEAACcQAAAAEDVLtMOoN4uc3IQad9ExkTk0ZqcXP+TFyC03PUTKaFH1WoEDubaWrOGOqCbmVCmxaQ==", "0551234567", false, "", "baceabba-a764-4389-9eb0-9cb72d6ef1b7", false, null, null },
                    { "3F2504E0-4F89-41D3-9A0C-0305E82C3302", 0, "4e0e7b29-109c-4e5d-bd9d-cc75a6cf65dd", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "bich_hang@example.com", false, "Bích Hằng", false, false, false, null, null, null, "AQAAAAEAACcQAAAAEKQqNFhV+nrX3yY6gZqJu2AufmIZetyo5xQR7PXxuOG+MYYYBleHyf6FOmLzC74KrA==", "0659876543", false, "", "cdd91ae5-41e9-4513-a2bb-40ed6ecd02b3", false, null, null },
                    { "3F2504E0-4F89-41D3-9A0C-0305E82C3306", 0, "edec3322-6293-47a2-b2a8-f06edee31120", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "lam_truong@example.com", false, "Lâm Trường", true, true, false, null, null, null, "AQAAAAEAACcQAAAAEKOtXZ8Mb63aZJPRlh7T9dwRmHvZTg85jyBxmvVTcZS0+P7+9tOR5zjMEtnHBFy9Yw==", "0852227890", false, "", "b152e5a5-ace4-40d4-a935-bc3c55dbd7f9", false, null, null },
                    { "3F2504E0-4F89-41D3-9A0C-0305E82C3307", 0, "5544df34-0a8b-4209-89e6-de681a37f762", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "linh_chau@example.com", false, "Linh Châu", false, false, false, null, null, null, "AQAAAAEAACcQAAAAEIdyJtBy5BWXR1CYKAXzXiiMm9taS0qrPL+FNXgqLlbdQievlme52aDb1EZ/lUvQew==", "0955556789", false, "", "9fda5038-c58d-4230-afed-56913ab5597c", false, null, null },
                    { "3F2504E0-4F89-41D3-9A0C-0305E82C3309", 0, "1125cb2c-7b33-43f4-bc1a-574847f51e26", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "quynh_nhu@example.com", false, "Quỳnh Như", false, false, false, null, null, null, "AQAAAAEAACcQAAAAEKq1oCKK5EPoX4RmTbH3W/LulICDajW1fpQaAvqBH5Vh4jFZWfjPNPt5zti5+f0HVg==", "0955555678", false, "", "af0f989e-c865-402e-b8b2-7b142f88594c", false, null, null },
                    { "3F2504E0-4F89-41D3-9A0C-0305E82C3310", 0, "0d7a517d-1342-4e59-92b3-321c03ce050b", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "HomeManager", "hoang_son@example.com", false, "Hoàng Sơn", false, true, false, null, null, null, "AQAAAAEAACcQAAAAEJVSwSIdLKkhY2pMwec7ycR6vdpDYfMSsN2GyPtaaICGX24jKehiXbBB3PYrB0YbEA==", "0955559012", false, "", "fd161e6e-0aa8-44b2-80f5-55cccc20b98e", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "BillStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Not Paid" },
                    { 2, "Paid" },
                    { 3, "Overdue" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Sent" },
                    { 2, "Pending" },
                    { 3, "Accepted" },
                    { 4, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "RequestTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Question" },
                    { 2, "Complain" },
                    { 3, "Request" },
                    { 4, "Suggestion" },
                    { 5, "Others" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "3F2504E0-4F89-41D3-9A0C-0305E82C3301" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "3F2504E0-4F89-41D3-9A0C-0305E82C3302" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "3F2504E0-4F89-41D3-9A0C-0305E82C3306" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "3F2504E0-4F89-41D3-9A0C-0305E82C3307" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "3F2504E0-4F89-41D3-9A0C-0305E82C3309" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "3F2504E0-4F89-41D3-9A0C-0305E82C3310" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "Description", "ElectricityPricePerMonth", "HomeManagerId", "IsDeleted", "Name", "UpdatedAt", "WaterPricePerMonth" },
                values: new object[,]
                {
                    { new Guid("2f2504e0-4f89-41d3-9a0c-0305e82c3304"), "456 Đường Phong", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả khác cho tòa nhà.", 2500.0m, "3F2504E0-4F89-41D3-9A0C-0305E82C3301", false, "Chung cư mini Lạc Quân", null, 22000.0m },
                    { new Guid("4f2504e0-4f89-41d3-9a0c-0305e82c3303"), "123 Đường Chính", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Đây là mô tả mẫu cho tòa nhà.", 2675.0m, "3F2504E0-4F89-41D3-9A0C-0305E82C3301", false, "Chung cư An Nhiên", null, 21000.0m },
                    { new Guid("5f2504e0-4f89-41d3-9a0c-0305e82c3305"), "789 Đường Sồi", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả khác cho tòa nhà.", 2700.0m, "3F2504E0-4F89-41D3-9A0C-0305E82C3302", false, "Tòa nhà 68", null, 15000.0m },
                    { new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), "1617 Đường Thông", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả cho tòa nhà.", 3500.0m, "3F2504E0-4F89-41D3-9A0C-0305E82C3307", false, "Chung cư mini 102", null, 27000.0m },
                    { new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "2223 Đường Vũ Bạch", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả cho tòa nhà.", 3400.0m, "3F2504E0-4F89-41D3-9A0C-0305E82C3310", false, "Trọ Vũ Bạch", null, 20000.0m },
                    { new Guid("ff2504e0-4f89-41d3-9a0c-0305e82c3312"), "2223 Stupid Street", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mô tả cho tòa nhà.", 3400.0m, "3F2504E0-4F89-41D3-9A0C-0305E82C3310", false, "ABC Apartment", null, 20000.0m }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "Description", "HomeManagerId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0b447141-a4eb-4444-9d6a-d35ba9693995"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.", "3F2504E0-4F89-41D3-9A0C-0305E82C3306", "Đóng tiền điện nước tháng 12/2023", null },
                    { new Guid("2a9306b5-7c9d-4cda-82c7-94c7641de97e"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.", "3F2504E0-4F89-41D3-9A0C-0305E82C3302", "Đóng tiền nhà tháng 1/2024", null },
                    { new Guid("68d0f123-4855-4004-bdf2-aeebae8f7bde"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đến giờ đóng tiền nhà rồi, không đóng không cho ở. Có 10 phút kể từ thông báo này để đóng.", "3F2504E0-4F89-41D3-9A0C-0305E82C3301", "Đóng tiền điện nước tháng 12/2023", null }
                });

            migrationBuilder.InsertData(
                table: "BuildingServices",
                columns: new[] { "Id", "BuildingId", "Name", "PricePerMonth" },
                values: new object[,]
                {
                    { new Guid("8f696d6a-034b-41af-949a-969f78935a22"), new Guid("9f2504e0-4f89-41d3-9a0c-0305e82c3309"), "Elevator Fee", 20000m },
                    { new Guid("9b9d671f-7196-49d2-9fe7-d439aa2dac3a"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "Parking Fee", 50000m },
                    { new Guid("c1690607-068b-47df-973d-7babb3efc1e8"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "Laundry Fee", 100000m },
                    { new Guid("f5610f03-3992-428c-8c45-d31309c72799"), new Guid("cf2504e0-4f89-41d3-9a0c-0305e82c3312"), "Trash Fee", 20000m }
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Discriminator", "Dob", "Email", "EmailConfirmed", "FullName", "IsDeleted", "IsMale", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PortraitPictureUrl", "RoomId", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "257862CB-BFD1-4D55-AB50-10D186E3E8F4", 0, "", "92e4b7b3-1fe9-4887-b3a7-b62223ee3cd4", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "yen123@example.com", false, "Vũ Hoàng Yến", false, false, false, null, null, "YEN123", "AQAAAAEAACcQAAAAED+7DMoqZ3Tu+aFhyat6eZUmS+NAsMutjh+64Zbf7bS/R+iNvCSCAScLO2jC9H3yXQ==", "0965432109", false, "", new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), "42993da7-52ba-4ae8-a0e6-3bc1a5e13a2f", false, null, "yen123" },
                    { "4F9038F6-DCFD-40D4-96ED-601686DB6B11", 0, "", "e0fdb94e-6127-4d6e-90b5-046525cdad96", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1986, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ptb@example.com", false, "Phạm Thị B", false, false, false, null, null, "PTB", "AQAAAAEAACcQAAAAEEpiIYCtrEdZMIwu+H/gxN5qgHLMn+9ZcqioZWfCkxKn6rTRmmzdjWULf4y7I2CxcA==", "0943210987", false, "", new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), "5cf9cbb7-4406-4560-873e-8fece1fdaf67", false, null, "ptb" },
                    { "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E", 0, "", "dcc1789a-fdeb-4f80-b325-42dcb9c55ca0", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1989, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "tte@example.com", false, "Trần Thị E", false, false, false, null, null, "TTE", "AQAAAAEAACcQAAAAEIwofQVg7J0ATs7LKSNtD5uxfUzkyFRyRhJj7yuomVgiPNpkd3zsLeyVkPp3e0bakQ==", "0910987654", false, "", new Guid("db740cec-f865-455b-874e-aa8e3436115f"), "c7231b2f-bb23-4921-94f4-072a193e8b36", false, null, "tte" },
                    { "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3", 0, "", "0e8ac560-4153-45c4-b470-1b40039055d1", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1985, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "tva@example.com", false, "Trần Văn A", false, true, false, null, null, "TVA", "AQAAAAEAACcQAAAAEMHp5C/CSws/+4pI1WfXbkE1McYTensYF+ZqfOfO7fBatc2dln1Cr+3DxaVe1rO1Mw==", "0954321098", false, "", new Guid("4f2504e0-4f89-41d3-7a0c-0305e82c3303"), "3a2aae43-f906-4cc8-ba99-f75d35c7fd56", false, null, "tva" },
                    { "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF", 0, "", "ec6a3f13-ba30-49e9-ac29-4b60ffa8114d", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1990, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email1@example.com", false, "Nguyễn Thị Linh", false, false, false, null, null, "LINH123", "AQAAAAEAACcQAAAAEIIntrcg/RDHm/BWH4LPIeellml+hW9XWI7JxW1HkIm7xFqyKzn7AUwcd99/Ltakyw==", "0987654321", false, "", new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), "a63968f3-6029-4dbe-b03b-fd9f93fc5805", false, null, "linh123" },
                    { "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012", 0, "", "b6e5b640-7eab-4b3e-a6e2-b9f2b5781b4b", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1987, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "lvc@example.com", false, "Phạm Thị C", false, false, false, null, null, "LVC", "AQAAAAEAACcQAAAAEKXD40Cs4Ccf/AoH6/govGx35wCV1eN98o0VM09pKW3eHvhac8o+qq/yjGGdkYOViw==", "0932109876", false, "", new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), "f511c9e8-97ac-4037-97d8-6e4c27127e6b", false, null, "lvc" },
                    { "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F", 0, "", "20486d0b-4577-483a-a345-82b3baae75fb", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1991, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "hyen4132@example.com", false, "Hoàng Thị Yến", false, false, false, null, null, "HYEN4132", "AQAAAAEAACcQAAAAEFnkTwAuaFH/2z2egf/x9ma/iRAddRJgAFtLYfEXIYUtgSmMT3f9Rqs33ltJINCnZw==", "0976543210", false, "", new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), "927064f0-6a92-4501-9d0d-34a8c14c6315", false, null, "hyen4132" },
                    { "FF4D981F-E335-4928-9F2C-DB378E6AFC5B", 0, "", "c3cecdcf-ac9e-406a-bb4f-fb4826279dc9", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenant", new DateTime(1988, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ntd@example.com", false, "Nguyễn Thị D", false, false, false, null, null, "NTD", "AQAAAAEAACcQAAAAED9DpQqJ9X7d2oUkWVRPvQG56F+kfZLnPJ9Om//GxKET9fD6x4DZxOfZ+RH6grgTsg==", "0921098765", false, "", new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), "e60c99c2-be33-4260-848e-4edf74f809eb", false, null, "ntd" }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "BillStatusId", "DeletedAt", "Description", "IsDeleted", "RoomId" },
                values: new object[] { new Guid("bfa7b59f-ba4d-4ddc-bfe4-49884dd0bd80"), 1, null, "", false, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "257862CB-BFD1-4D55-AB50-10D186E3E8F4" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "4F9038F6-DCFD-40D4-96ED-601686DB6B11" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F" },
                    { "2c5e174e-3b0e-446f-86af-583d56fd7210", "FF4D981F-E335-4928-9F2C-DB378E6AFC5B" }
                });

            migrationBuilder.InsertData(
                table: "BillDetails",
                columns: new[] { "Id", "BillId", "CreatedAt", "CurrentElectricityReading", "CurrentWaterReading", "ElectricityPricePerMonth", "PreviousElectricityReading", "PreviousWaterReading", "RoomRentPrice", "UpdatedAt", "WaterPricePerMonth" },
                values: new object[] { new Guid("fd5aabe7-f87b-4d27-9896-91a1ef83a91e"), new Guid("bfa7b59f-ba4d-4ddc-bfe4-49884dd0bd80"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1161, 120, 3200m, 1030, 100, 4000000m, null, 15000m });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "CheckInDate", "CreatedAt", "DeletedAt", "Deposit", "ExpectedCheckOutDate", "HomeManagerId", "IsDeleted", "Note", "NumberOfTenants", "RealCheckOutDate", "RequestStatusId", "RoomId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08be2e31-4abb-446c-8b22-d25d140aa0d7"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "3F2504E0-4F89-41D3-9A0C-0305E82C3301", false, "", 3, null, null, new Guid("4f2504e0-4f89-41d3-8a0c-0305e82c3303"), "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF", null },
                    { new Guid("40c3a2c4-dede-4722-be95-48a67c45f552"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "3F2504E0-4F89-41D3-9A0C-0305E82C3301", false, "", 2, null, null, new Guid("4f2504e0-4f89-41d3-7a0c-0305e82c3303"), "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3", null },
                    { new Guid("417a93ea-bc60-4c30-a4c1-d3b856889b08"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "3F2504E0-4F89-41D3-9A0C-0305E82C3302", false, "", 1, null, null, new Guid("db740cec-f865-455b-874e-aa8e3436115f"), "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E", null },
                    { new Guid("df9af346-6a2e-4930-ad39-5480c984eff9"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3000000m, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "3F2504E0-4F89-41D3-9A0C-0305E82C3301", false, "", 3, null, null, new Guid("cbf552c9-bbfb-4920-9f43-9782c33d88e8"), "4F9038F6-DCFD-40D4-96ED-601686DB6B11", null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsReaded", "Message", "RequestStatusId", "TenantId" },
                values: new object[,]
                {
                    { new Guid("74f47318-9d30-47f0-9d6b-623c60acd9e7"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Đóng tiền nhà tháng 12/2023", null, "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF" },
                    { new Guid("8088bf14-7543-4d5f-bb03-891998318b87"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Đóng tiền nhà tháng 12/2023", null, "257862CB-BFD1-4D55-AB50-10D186E3E8F4" },
                    { new Guid("acdf8315-a60b-469d-90eb-e450ebb1526c"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Đóng tiền nhà tháng 12/2023", null, "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "HomeManagerId", "IsDeleted", "RequestStatusId", "RequestTypeId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9d387606-2a10-4119-b5a5-16176626de19"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Có điều khiển điều hòa không?", "3F2504E0-4F89-41D3-9A0C-0305E82C3306", false, 3, 1, "257862CB-BFD1-4D55-AB50-10D186E3E8F4", null },
                    { new Guid("ba9f1f1a-46ad-4ebd-a5e3-f26daae31812"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm bình nóng lạnh", "3F2504E0-4F89-41D3-9A0C-0305E82C3306", false, 2, 4, "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F", null },
                    { new Guid("f9d7aac9-6978-4b71-b6ab-f56ac147f8b3"), new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Không có nước", "3F2504E0-4F89-41D3-9A0C-0305E82C3301", false, 1, 2, "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoomId",
                table: "AspNetUsers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Contracts_RequestStatusId",
                table: "Contracts",
                column: "RequestStatusId");

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
                name: "IX_Notifications_RequestStatusId",
                table: "Notifications",
                column: "RequestStatusId");

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
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_AspNetUsers_HomeManagerId",
                table: "Buildings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
