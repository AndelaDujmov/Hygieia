using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4625e384-e2d1-46a8-afaa-4209ab385752"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46478b8f-eb12-4fad-9aff-f808f1cd03e3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a38a6fc2-ae9f-44e7-8714-cfd446e0ab61"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41c137b0-2db9-45a3-be1a-3eb8ed185575"), 2 },
                    { new Guid("8d3144a4-0112-40fa-af4b-fd97323c9709"), 0 },
                    { new Guid("bbc2351d-d5ca-4442-bc5f-9ba41a8c55db"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("41c137b0-2db9-45a3-be1a-3eb8ed185575"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d3144a4-0112-40fa-af4b-fd97323c9709"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bbc2351d-d5ca-4442-bc5f-9ba41a8c55db"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4625e384-e2d1-46a8-afaa-4209ab385752"), 0 },
                    { new Guid("46478b8f-eb12-4fad-9aff-f808f1cd03e3"), 1 },
                    { new Guid("a38a6fc2-ae9f-44e7-8714-cfd446e0ab61"), 2 }
                });
        }
    }
}
