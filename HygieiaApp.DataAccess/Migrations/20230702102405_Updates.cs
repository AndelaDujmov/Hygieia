using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0997cbb1-7a9f-4ba5-a99b-06d3b7d22562"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d6f087d8-3c2a-47db-98bd-e8863fcd9a85"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e2a2453e-8803-4a77-95c0-e463744d2240"));
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3bb7950b-54c9-4915-837c-7f2461ebfd27"), 2 },
                    { new Guid("b2a4408c-0e12-44c2-bc8c-d98084fc7f0b"), 0 },
                    { new Guid("c01e7ba8-1650-4be6-8ca6-312bbd4fc472"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3bb7950b-54c9-4915-837c-7f2461ebfd27"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2a4408c-0e12-44c2-bc8c-d98084fc7f0b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c01e7ba8-1650-4be6-8ca6-312bbd4fc472"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0997cbb1-7a9f-4ba5-a99b-06d3b7d22562"), 2 },
                    { new Guid("d6f087d8-3c2a-47db-98bd-e8863fcd9a85"), 1 },
                    { new Guid("e2a2453e-8803-4a77-95c0-e463744d2240"), 0 }
                });
        }
    }
}
