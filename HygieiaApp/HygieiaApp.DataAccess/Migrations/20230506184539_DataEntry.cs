using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4b749219-46e7-4028-b44e-96e2655d5a4f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("78e04ae0-aed5-412c-ae1e-805b490aaf18"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d29cd9cd-bb48-44de-a69e-3836503452b1"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("255ccbb2-2c45-4913-abe8-3312d5efc2c3"), 1 },
                    { new Guid("8db39293-64ef-4e77-948b-26a897e131bf"), 2 },
                    { new Guid("b924535a-89c5-4477-8458-cf367db47224"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("255ccbb2-2c45-4913-abe8-3312d5efc2c3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8db39293-64ef-4e77-948b-26a897e131bf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b924535a-89c5-4477-8458-cf367db47224"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4b749219-46e7-4028-b44e-96e2655d5a4f"), 1 },
                    { new Guid("78e04ae0-aed5-412c-ae1e-805b490aaf18"), 0 },
                    { new Guid("d29cd9cd-bb48-44de-a69e-3836503452b1"), 2 }
                });
        }
    }
}
