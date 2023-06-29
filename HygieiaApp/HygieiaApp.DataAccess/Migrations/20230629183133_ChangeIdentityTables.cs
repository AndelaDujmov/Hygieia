using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("80de1075-53ef-49c9-bfec-2943aa9036fe"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac2b73ea-510d-4b78-a5f9-6832bc341546"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e24420b9-a575-49db-bc32-bf29ac6f9c90"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36023824-406c-4fcd-92cd-2d95ecea8963"), 0 },
                    { new Guid("b9e7bdf2-33b2-4938-824a-ea65db5cee92"), 2 },
                    { new Guid("d89ab0d7-4451-4914-b808-31fc684eda3a"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("36023824-406c-4fcd-92cd-2d95ecea8963"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b9e7bdf2-33b2-4938-824a-ea65db5cee92"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d89ab0d7-4451-4914-b808-31fc684eda3a"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("80de1075-53ef-49c9-bfec-2943aa9036fe"), 2 },
                    { new Guid("ac2b73ea-510d-4b78-a5f9-6832bc341546"), 1 },
                    { new Guid("e24420b9-a575-49db-bc32-bf29ac6f9c90"), 0 }
                });
        }
    }
}
