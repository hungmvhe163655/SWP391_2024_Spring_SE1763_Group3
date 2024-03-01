using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendCore.Migrations
{
    /// <inheritdoc />
    public partial class refreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "09aee4f3-6caa-45c9-bd79-909f07d4f490");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-583d56fd7210",
                column: "ConcurrencyStamp",
                value: "c19a843d-9f6b-45d9-b18c-425a8e247d76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-683d56fd7210",
                column: "ConcurrencyStamp",
                value: "ddf6f04c-18d0-4eef-b630-821802973f6d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "257862CB-BFD1-4D55-AB50-10D186E3E8F4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "b89d1439-1799-4400-8bee-bbf02e0f2c2f", "AQAAAAEAACcQAAAAEDwnR71CXw4/E1T+IwRYJvaGpROI7sXRlf1SSj7DnGHI3+AkQaFEAWpeXs83Ma8fJQ==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3fdbf2b3-fd51-4a17-996c-67e923dab87f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "8c0d4042-5861-4b77-bfad-d974aacfb14e", "AQAAAAEAACcQAAAAEI7zB8EprsdTXt+KEgQ6wvSaxKIB6vyXBHIIHYlfN0t1xflXpimlfRPL5ENdbOGToA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e82c3f38-a723-4394-b38e-d0d6dc847f27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3302",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "0ab10acc-d630-4699-9e08-a0c360d758ad", "AQAAAAEAACcQAAAAEJ7ai4YQh+cxRZtuSTFfBHXHi/p8qwNFaDsKXSzCOkddeK2s36tUMWoL9Nekk1yjSA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "09af95b5-6896-4d99-b1f0-6760a83d89d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "44dde0a9-aaa4-4378-8322-07cb784a667b", "AQAAAAEAACcQAAAAEPymn9ymQJSfDPS35H4gA6bxzh4SLx4u7ENgCL0DSVGcB5BnN2CMFk6ysybz1dNvUQ==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d85c73b4-0796-4b50-b385-ab01017d115f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3307",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "180b1220-431a-45d4-bc3c-b6b218ab04b5", "AQAAAAEAACcQAAAAEKUA8Lr7ncsVnpePRZc70heFHBoJz7KlJulTLF7s/RLOsltm+n4PGF0yCgaZjimGSg==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "99b57b17-b03c-4bf4-867a-41e0107c5d5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3309",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "a6146dcb-371d-43d2-aeec-af88ff84fac7", "AQAAAAEAACcQAAAAEJjc0B3huYUbSukRgFRb5kLpLa9K+ttxh4Gn/PFjpNBBCblEiByvAUOrRP6DL9ZwSw==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a699d608-9915-48de-b2f5-4df63c4835ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3310",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "8b1ce750-7c8c-411d-8ef4-523b9abb639e", "AQAAAAEAACcQAAAAEF5tO4YMM+s7ACo5yw7cnlbWr7dp7gaXaqQR4SwZ0x6XpYjtYpW5OVuM7nBMT6i5yg==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eae23008-9d3f-471a-bc77-f6813df1dc55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F9038F6-DCFD-40D4-96ED-601686DB6B11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "c1dcf37f-4b42-40c1-aca2-a8c540e8fe7f", "AQAAAAEAACcQAAAAEOjzmhqHbbsdnsB4BPyUI/caexhSciwLNw7GYLr16rV38Qov7n9pcVMUirHR5EOGGA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "78cb9121-637f-4d7a-8f66-fedbb387ef40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "352aa57c-23da-4713-88e7-7d793d250e22", "AQAAAAEAACcQAAAAEIMUEIIn6O8pICYlf3Cp78uXKR2PHOpJUvlqhzv0Wc1xSKvye6ycE2L2KcC4jxfJbw==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "44186dcb-d9d7-41f5-abde-01cd5e4191b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "efdc7cb8-c40b-4bbe-973f-8c2985e5764e", "AQAAAAEAACcQAAAAEM7EKOVtguqoRvCqM5LsiYCug/n9SSJy50wcVlaRIgZ7hDgagkGMX7m+bkOu88DgTQ==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a65ae473-74ff-4398-8d5a-b1cc23821158" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "b56e17ff-dafa-4dbf-b42f-0044d4e45864", "AQAAAAEAACcQAAAAEMX5z5q9MySFiL/SbvWwO/FPC5JqXo9xRYKdv7/a/g5ciBduZu6tE3V3DkRPUkMyaA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfa3bcb4-ced8-4a96-af58-3b2887391c49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "fdff55bd-9c49-4713-85cb-3a1ca6caac66", "AQAAAAEAACcQAAAAEMKvwDQ7jP39dkGjnKQ7HpprOtQ1XEMqXdCNTvOMjdt7Jmv9zNJIIjGGC0NuxiFvbg==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bff54f31-bb5f-45f7-9c70-4f568356d96d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "1da8000d-5aa7-4e2d-8390-abbc82ff3540", "AQAAAAEAACcQAAAAEOQ5eqAjXfGOyFQTg6QM0dgs/oC8432J/JuFwPApKaffnjlNNoqPozkouoSEbMNtDg==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "563b19c0-0a15-4ce1-a690-dd969452d6ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FF4D981F-E335-4928-9F2C-DB378E6AFC5B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "be61d7b4-4bac-445a-8afc-8cd62d296448", "AQAAAAEAACcQAAAAEKVm1l/lX07WpGVGWkRbEBeIJa7ptvK86cZQh6RhcvOOLZMgAjwOwOG41QvAC17RDA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "62e3e043-047d-4a98-87d0-0274aa27c23f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f37016d3-5406-46bf-a45c-411b0580d72b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-583d56fd7210",
                column: "ConcurrencyStamp",
                value: "25881f61-aad4-41c6-9407-d01d06d66e40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-683d56fd7210",
                column: "ConcurrencyStamp",
                value: "ddf50698-f1c7-466f-a504-407286fb514c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "257862CB-BFD1-4D55-AB50-10D186E3E8F4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92e4b7b3-1fe9-4887-b3a7-b62223ee3cd4", "AQAAAAEAACcQAAAAED+7DMoqZ3Tu+aFhyat6eZUmS+NAsMutjh+64Zbf7bS/R+iNvCSCAScLO2jC9H3yXQ==", "42993da7-52ba-4ae8-a0e6-3bc1a5e13a2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd7811be-7672-48b3-8656-ce4c51bcf07e", "AQAAAAEAACcQAAAAEDVLtMOoN4uc3IQad9ExkTk0ZqcXP+TFyC03PUTKaFH1WoEDubaWrOGOqCbmVCmxaQ==", "baceabba-a764-4389-9eb0-9cb72d6ef1b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3302",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e0e7b29-109c-4e5d-bd9d-cc75a6cf65dd", "AQAAAAEAACcQAAAAEKQqNFhV+nrX3yY6gZqJu2AufmIZetyo5xQR7PXxuOG+MYYYBleHyf6FOmLzC74KrA==", "cdd91ae5-41e9-4513-a2bb-40ed6ecd02b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edec3322-6293-47a2-b2a8-f06edee31120", "AQAAAAEAACcQAAAAEKOtXZ8Mb63aZJPRlh7T9dwRmHvZTg85jyBxmvVTcZS0+P7+9tOR5zjMEtnHBFy9Yw==", "b152e5a5-ace4-40d4-a935-bc3c55dbd7f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3307",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5544df34-0a8b-4209-89e6-de681a37f762", "AQAAAAEAACcQAAAAEIdyJtBy5BWXR1CYKAXzXiiMm9taS0qrPL+FNXgqLlbdQievlme52aDb1EZ/lUvQew==", "9fda5038-c58d-4230-afed-56913ab5597c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3309",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1125cb2c-7b33-43f4-bc1a-574847f51e26", "AQAAAAEAACcQAAAAEKq1oCKK5EPoX4RmTbH3W/LulICDajW1fpQaAvqBH5Vh4jFZWfjPNPt5zti5+f0HVg==", "af0f989e-c865-402e-b8b2-7b142f88594c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3310",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d7a517d-1342-4e59-92b3-321c03ce050b", "AQAAAAEAACcQAAAAEJVSwSIdLKkhY2pMwec7ycR6vdpDYfMSsN2GyPtaaICGX24jKehiXbBB3PYrB0YbEA==", "fd161e6e-0aa8-44b2-80f5-55cccc20b98e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F9038F6-DCFD-40D4-96ED-601686DB6B11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0fdb94e-6127-4d6e-90b5-046525cdad96", "AQAAAAEAACcQAAAAEEpiIYCtrEdZMIwu+H/gxN5qgHLMn+9ZcqioZWfCkxKn6rTRmmzdjWULf4y7I2CxcA==", "5cf9cbb7-4406-4560-873e-8fece1fdaf67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcc1789a-fdeb-4f80-b325-42dcb9c55ca0", "AQAAAAEAACcQAAAAEIwofQVg7J0ATs7LKSNtD5uxfUzkyFRyRhJj7yuomVgiPNpkd3zsLeyVkPp3e0bakQ==", "c7231b2f-bb23-4921-94f4-072a193e8b36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e8ac560-4153-45c4-b470-1b40039055d1", "AQAAAAEAACcQAAAAEMHp5C/CSws/+4pI1WfXbkE1McYTensYF+ZqfOfO7fBatc2dln1Cr+3DxaVe1rO1Mw==", "3a2aae43-f906-4cc8-ba99-f75d35c7fd56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec6a3f13-ba30-49e9-ac29-4b60ffa8114d", "AQAAAAEAACcQAAAAEIIntrcg/RDHm/BWH4LPIeellml+hW9XWI7JxW1HkIm7xFqyKzn7AUwcd99/Ltakyw==", "a63968f3-6029-4dbe-b03b-fd9f93fc5805" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6e5b640-7eab-4b3e-a6e2-b9f2b5781b4b", "AQAAAAEAACcQAAAAEKXD40Cs4Ccf/AoH6/govGx35wCV1eN98o0VM09pKW3eHvhac8o+qq/yjGGdkYOViw==", "f511c9e8-97ac-4037-97d8-6e4c27127e6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20486d0b-4577-483a-a345-82b3baae75fb", "AQAAAAEAACcQAAAAEFnkTwAuaFH/2z2egf/x9ma/iRAddRJgAFtLYfEXIYUtgSmMT3f9Rqs33ltJINCnZw==", "927064f0-6a92-4501-9d0d-34a8c14c6315" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FF4D981F-E335-4928-9F2C-DB378E6AFC5B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3cecdcf-ac9e-406a-bb4f-fb4826279dc9", "AQAAAAEAACcQAAAAED9DpQqJ9X7d2oUkWVRPvQG56F+kfZLnPJ9Om//GxKET9fD6x4DZxOfZ+RH6grgTsg==", "e60c99c2-be33-4260-848e-4edf74f809eb" });
        }
    }
}
