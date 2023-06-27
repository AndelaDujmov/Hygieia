using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1376899d-8e75-4772-bdd9-48c3ebc1cd2e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("297724c0-ff16-480e-978f-fb992a7ec5dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5d848e25-240e-4938-927b-8fb45cd49914"));

            migrationBuilder.AddColumn<int>(
                name: "MBO",
                table: "Users",
                type: "int",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OIB",
                table: "Users",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24a3c346-58b7-4015-a27c-1d9ffaa31f55"), 1 },
                    { new Guid("8f7ca601-5129-4be5-bb47-ed3358e35d13"), 2 },
                    { new Guid("a10bbb6c-332c-4354-9b4f-b81e94efa667"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("24a3c346-58b7-4015-a27c-1d9ffaa31f55"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f7ca601-5129-4be5-bb47-ed3358e35d13"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a10bbb6c-332c-4354-9b4f-b81e94efa667"));

            migrationBuilder.DropColumn(
                name: "MBO",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OIB",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1376899d-8e75-4772-bdd9-48c3ebc1cd2e"), 2 },
                    { new Guid("297724c0-ff16-480e-978f-fb992a7ec5dd"), 1 },
                    { new Guid("5d848e25-240e-4938-927b-8fb45cd49914"), 0 }
                });
        }
    }
}
