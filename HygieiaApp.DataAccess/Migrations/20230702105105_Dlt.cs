using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Dlt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn("Name", "AspNetUsers");
            migrationBuilder.DropColumn("Oib", "AspNetUsers");
            migrationBuilder.DropColumn("Mbo", "AspNetUsers");
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2e4bc4e2-b572-4239-81ca-923ead7edfa9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("31f2b781-e023-44e1-a189-c856eba3f1c5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5814f21a-1dbc-4890-9d03-cd2f68d7f47d"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2e4bc4e2-b572-4239-81ca-923ead7edfa9"), 2 },
                    { new Guid("31f2b781-e023-44e1-a189-c856eba3f1c5"), 1 },
                    { new Guid("5814f21a-1dbc-4890-9d03-cd2f68d7f47d"), 0 }
                });
        }
    }
}
