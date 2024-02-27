using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendCore.Migrations
{
    /// <inheritdoc />
    public partial class removeUnecessaryRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_RequestStatuses_RequestStatusId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_RequestStatuses_RequestStatusId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_RequestStatusId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_RequestStatusId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Contracts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a469b42a-030b-4947-aa45-be9c7ea4344a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-583d56fd7210",
                column: "ConcurrencyStamp",
                value: "ba5fb658-921d-49ba-acbf-5dc17c333317");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-683d56fd7210",
                column: "ConcurrencyStamp",
                value: "df61f09e-400b-4aab-a624-73d7d0007753");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "257862CB-BFD1-4D55-AB50-10D186E3E8F4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de3aec39-5155-49ac-941a-9fa496a29a79", "AQAAAAEAACcQAAAAEMlkdP7Um3emVFhnU0OL8k0O0UINoRrmkEtLuSbFI0oBU7ivyOjxev9X4fV5j83aMA==", "7dc435b1-ca87-45f7-b8e4-7f5fce48f4d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08aa882a-0aaa-4247-966f-decbc3261d49", "AQAAAAEAACcQAAAAEDJ7M0PUKQqegh621gexnITg9IkjTWsc+pcs55sQLENdWT/aRv7pnNbsAVrOOOEaDQ==", "7444d2c1-06ba-4e94-b457-190a18a05a53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3302",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb8ef06d-a438-4abd-a010-04dab0195a9b", "AQAAAAEAACcQAAAAEHZ4Ll2YP5IXJDoCbOgXM7vGynzsOxj53FaOMVx60wXXP0YsKjxBy20t2JRvl5elag==", "6b4d6ac5-2078-41ef-8124-d186204993f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "992bdeef-8d38-497f-b69b-d1bfe1e6a430", "AQAAAAEAACcQAAAAEFNUAt2V4WsL4kLeOBNB0S0E6vBK9Yyiy5xZZkikAoXXh4nuUC6i4EGirUe+/ACSFQ==", "09362aa9-24bf-469b-891f-2fd9c868bd51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3307",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8164199-231e-4bed-8021-ba773c500b88", "AQAAAAEAACcQAAAAEAYnzvjxbea3Lz7JxWLCBXuOxs49x8aRAD778UHEGkkvprApl82A2nF4HkHLOLFLUQ==", "b28515d2-d009-40ed-a7c2-48ff902e6378" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3309",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48df2b4d-1a0c-4c4f-b22a-43564d2e4bed", "AQAAAAEAACcQAAAAEEkuXUvlndW2U0vGMp4DS64i9sOgu5/ahdquXG/v0aAyCFHkbF0uhsToSTZ9Rv2XTQ==", "447ab671-5ec1-4ba4-971c-21956e39172e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3310",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f93533c2-e5d8-480e-9f10-c09dce332437", "AQAAAAEAACcQAAAAEHcVRHY11/UtP1hWaBc1NSVyicgGkkv61b+gWnqdDAUSDSEHdIdugjRFgb4Lj9BlWg==", "8d1b8d7c-6084-4a13-8908-ae4f36440868" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F9038F6-DCFD-40D4-96ED-601686DB6B11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88a7974b-f2d0-4605-9310-b980ab3f6f8d", "AQAAAAEAACcQAAAAECrWnvWYDMoMwBZsvkA5l7bpk6Y7dSdqU2E8yJ/YyHnBhyyWyuIrXkM7sEDItW3boQ==", "bbfe8011-c233-4244-8e44-eb2c2d1f8825" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4903cef-8cef-4f0d-acf1-80488365b2cf", "AQAAAAEAACcQAAAAEC4D72vFhLCMKK+43XEYl6dJjbAYxFzCGQiUvfEptcS5N6Sdjy8hO+qQ5WFJhHpfbA==", "ae57775b-0dd6-46e3-a2c3-b1b3dce3c3ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d841bfd-5fc0-42a3-b707-5fdfe86ec95e", "AQAAAAEAACcQAAAAEDLfUafFgXgUy31mfNiNabkTFzC7W/z5ZWpf1HuFpCv5rJCOznEKxG434jLemQmVQg==", "71082f24-b5c9-47bf-a03f-a03e7ece2f91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0175444-b19c-474b-91b7-d99bdcb7b27e", "AQAAAAEAACcQAAAAEKazoi7PbYiQ8XzQViUQRIp238+PRoF3zD/MjYz5WpsucVIntRMwUc3JDiGCp+W21Q==", "fc0d54d5-862f-4634-9473-414e895d86fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2144294-5cbd-4d08-acbf-6f6ed57ab2b5", "AQAAAAEAACcQAAAAEEThgzpSKzEoziTpi8JmD1Cpc9OxQgT8GYGeFQ2aD/cptHnsf19ceKlxxtTFnTkEgw==", "5f90df1f-d93f-44f6-9d9f-d0a6b060fabf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c6296f6-18fa-4a06-b165-a1d8abf0a98f", "AQAAAAEAACcQAAAAEANS30/o5nNJ5JHvZYKuYZIjU2zpYONEwustQV51O6ZGUXburku5dO4O+yjDjkiW1g==", "80a0afaa-1482-4c31-a5a6-00e3affc948c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FF4D981F-E335-4928-9F2C-DB378E6AFC5B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ecf78f-2f93-4aa1-af4e-eb3b6c11dedd", "AQAAAAEAACcQAAAAEA5qsik175+jUehGzb2ig53NiQsKqGhj/OYLqc7ewO3AvkiJfbJybvEM4WdghIbonQ==", "0c004f26-cff4-4c11-a3b7-7d92eb20426e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Contracts",
                type: "int",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b89d1439-1799-4400-8bee-bbf02e0f2c2f", "AQAAAAEAACcQAAAAEDwnR71CXw4/E1T+IwRYJvaGpROI7sXRlf1SSj7DnGHI3+AkQaFEAWpeXs83Ma8fJQ==", "3fdbf2b3-fd51-4a17-996c-67e923dab87f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c0d4042-5861-4b77-bfad-d974aacfb14e", "AQAAAAEAACcQAAAAEI7zB8EprsdTXt+KEgQ6wvSaxKIB6vyXBHIIHYlfN0t1xflXpimlfRPL5ENdbOGToA==", "e82c3f38-a723-4394-b38e-d0d6dc847f27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3302",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab10acc-d630-4699-9e08-a0c360d758ad", "AQAAAAEAACcQAAAAEJ7ai4YQh+cxRZtuSTFfBHXHi/p8qwNFaDsKXSzCOkddeK2s36tUMWoL9Nekk1yjSA==", "09af95b5-6896-4d99-b1f0-6760a83d89d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44dde0a9-aaa4-4378-8322-07cb784a667b", "AQAAAAEAACcQAAAAEPymn9ymQJSfDPS35H4gA6bxzh4SLx4u7ENgCL0DSVGcB5BnN2CMFk6ysybz1dNvUQ==", "d85c73b4-0796-4b50-b385-ab01017d115f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3307",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "180b1220-431a-45d4-bc3c-b6b218ab04b5", "AQAAAAEAACcQAAAAEKUA8Lr7ncsVnpePRZc70heFHBoJz7KlJulTLF7s/RLOsltm+n4PGF0yCgaZjimGSg==", "99b57b17-b03c-4bf4-867a-41e0107c5d5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3309",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6146dcb-371d-43d2-aeec-af88ff84fac7", "AQAAAAEAACcQAAAAEJjc0B3huYUbSukRgFRb5kLpLa9K+ttxh4Gn/PFjpNBBCblEiByvAUOrRP6DL9ZwSw==", "a699d608-9915-48de-b2f5-4df63c4835ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3F2504E0-4F89-41D3-9A0C-0305E82C3310",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b1ce750-7c8c-411d-8ef4-523b9abb639e", "AQAAAAEAACcQAAAAEF5tO4YMM+s7ACo5yw7cnlbWr7dp7gaXaqQR4SwZ0x6XpYjtYpW5OVuM7nBMT6i5yg==", "eae23008-9d3f-471a-bc77-f6813df1dc55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4F9038F6-DCFD-40D4-96ED-601686DB6B11",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1dcf37f-4b42-40c1-aca2-a8c540e8fe7f", "AQAAAAEAACcQAAAAEOjzmhqHbbsdnsB4BPyUI/caexhSciwLNw7GYLr16rV38Qov7n9pcVMUirHR5EOGGA==", "78cb9121-637f-4d7a-8f66-fedbb387ef40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86F1E1D1-5AB7-48D3-8B14-97B0AD42018E",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "352aa57c-23da-4713-88e7-7d793d250e22", "AQAAAAEAACcQAAAAEIMUEIIn6O8pICYlf3Cp78uXKR2PHOpJUvlqhzv0Wc1xSKvye6ycE2L2KcC4jxfJbw==", "44186dcb-d9d7-41f5-abde-01cd5e4191b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A1E1F042-AB4A-431E-8A8E-710E2ECEFFC3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efdc7cb8-c40b-4bbe-973f-8c2985e5764e", "AQAAAAEAACcQAAAAEM7EKOVtguqoRvCqM5LsiYCug/n9SSJy50wcVlaRIgZ7hDgagkGMX7m+bkOu88DgTQ==", "a65ae473-74ff-4398-8d5a-b1cc23821158" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B4E6EA80-F066-44F4-AA55-30E0A0FE30AF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b56e17ff-dafa-4dbf-b42f-0044d4e45864", "AQAAAAEAACcQAAAAEMX5z5q9MySFiL/SbvWwO/FPC5JqXo9xRYKdv7/a/g5ciBduZu6tE3V3DkRPUkMyaA==", "dfa3bcb4-ced8-4a96-af58-3b2887391c49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D7FBD8C3-8D8A-4DBB-BE44-34B9D9C6D012",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdff55bd-9c49-4713-85cb-3a1ca6caac66", "AQAAAAEAACcQAAAAEMKvwDQ7jP39dkGjnKQ7HpprOtQ1XEMqXdCNTvOMjdt7Jmv9zNJIIjGGC0NuxiFvbg==", "bff54f31-bb5f-45f7-9c70-4f568356d96d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F63C6963-7A41-4AB5-AD8E-4FEF8A8A843F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1da8000d-5aa7-4e2d-8390-abbc82ff3540", "AQAAAAEAACcQAAAAEOQ5eqAjXfGOyFQTg6QM0dgs/oC8432J/JuFwPApKaffnjlNNoqPozkouoSEbMNtDg==", "563b19c0-0a15-4ce1-a690-dd969452d6ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FF4D981F-E335-4928-9F2C-DB378E6AFC5B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be61d7b4-4bac-445a-8afc-8cd62d296448", "AQAAAAEAACcQAAAAEKVm1l/lX07WpGVGWkRbEBeIJa7ptvK86cZQh6RhcvOOLZMgAjwOwOG41QvAC17RDA==", "62e3e043-047d-4a98-87d0-0274aa27c23f" });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("08be2e31-4abb-446c-8b22-d25d140aa0d7"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("40c3a2c4-dede-4722-be95-48a67c45f552"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("417a93ea-bc60-4c30-a4c1-d3b856889b08"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: new Guid("df9af346-6a2e-4930-ad39-5480c984eff9"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("74f47318-9d30-47f0-9d6b-623c60acd9e7"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("8088bf14-7543-4d5f-bb03-891998318b87"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("acdf8315-a60b-469d-90eb-e450ebb1526c"),
                column: "RequestStatusId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RequestStatusId",
                table: "Notifications",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RequestStatusId",
                table: "Contracts",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_RequestStatuses_RequestStatusId",
                table: "Contracts",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_RequestStatuses_RequestStatusId",
                table: "Notifications",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");
        }
    }
}
