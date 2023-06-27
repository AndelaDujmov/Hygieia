using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestResultsPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("665e42d1-c34b-4809-93d1-bdd1df1006c1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("af4cdeef-7f02-457f-be50-9bbe23efec16"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e178f2ae-23b5-4089-9f38-1c9f5805786b"));

            migrationBuilder.CreateTable(
                name: "TestResultsPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateOfTesting = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Results = table.Column<string>(type: "longtext", nullable: false),
                    PatientId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultsPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResultsPatients_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("99ebc5c3-0fce-4f6d-93f6-94e372118aeb"), 0 },
                    { new Guid("ac1d57bd-e436-4961-942b-9a71063ec3fa"), 2 },
                    { new Guid("bf36a75f-51ab-4a6d-ba34-b757abba6a3a"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestResultsPatients_PatientId",
                table: "TestResultsPatients",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResultsPatients");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("99ebc5c3-0fce-4f6d-93f6-94e372118aeb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac1d57bd-e436-4961-942b-9a71063ec3fa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf36a75f-51ab-4a6d-ba34-b757abba6a3a"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("665e42d1-c34b-4809-93d1-bdd1df1006c1"), 0 },
                    { new Guid("af4cdeef-7f02-457f-be50-9bbe23efec16"), 2 },
                    { new Guid("e178f2ae-23b5-4089-9f38-1c9f5805786b"), 1 }
                });
        }
    }
}
