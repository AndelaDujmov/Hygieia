using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ImmunizationPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Immunizations");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Schedulers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PatientMedicalConditions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PatientDoctors",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MedicalConditionMedications",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MedicalConditionMedicateds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ImmunizationPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateOfVaccination = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImmunizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunizationPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmunizationPatients_Immunizations_ImmunizationId",
                        column: x => x.ImmunizationId,
                        principalTable: "Immunizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImmunizationPatients_Users_UserId",
                        column: x => x.UserId,
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
                    { new Guid("665e42d1-c34b-4809-93d1-bdd1df1006c1"), 0 },
                    { new Guid("af4cdeef-7f02-457f-be50-9bbe23efec16"), 2 },
                    { new Guid("e178f2ae-23b5-4089-9f38-1c9f5805786b"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationPatients_ImmunizationId",
                table: "ImmunizationPatients",
                column: "ImmunizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationPatients_UserId",
                table: "ImmunizationPatients",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImmunizationPatients");

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

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PatientMedicalConditions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PatientDoctors");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MedicalConditionMedications");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MedicalConditionMedicateds");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Immunizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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
    }
}
