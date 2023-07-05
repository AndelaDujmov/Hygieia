using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b78c3ae-9da6-4248-8ada-b842be70e8b4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6640a0b3-bfc7-4a6e-a28e-9ed84083e68a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d9c6c46e-7209-40a4-9b6c-990a16b18178"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<long>(
                name: "Mbo",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Oib",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fbe4c7b-0586-4f4b-a12a-8ea056c2244d"), 1 },
                    { new Guid("cf857f61-3d12-4414-9863-1d3e924320f3"), 0 },
                    { new Guid("e0acb36e-bf3d-4a30-913d-4cb7c0eb0a8d"), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0fbe4c7b-0586-4f4b-a12a-8ea056c2244d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf857f61-3d12-4414-9863-1d3e924320f3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e0acb36e-bf3d-4a30-913d-4cb7c0eb0a8d"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Mbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Oib",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b78c3ae-9da6-4248-8ada-b842be70e8b4"), 2 },
                    { new Guid("6640a0b3-bfc7-4a6e-a28e-9ed84083e68a"), 1 },
                    { new Guid("d9c6c46e-7209-40a4-9b6c-990a16b18178"), 0 }
                });
        }
    }
}
