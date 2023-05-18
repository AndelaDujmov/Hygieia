using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Users_DoctorId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Users_PatientId",
                table: "PatientDoctors");

            migrationBuilder.DropIndex(
                name: "IX_PatientDoctors_DoctorId",
                table: "PatientDoctors");

            migrationBuilder.DropIndex(
                name: "IX_PatientDoctors_PatientId",
                table: "PatientDoctors");

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

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "PatientDoctors");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientDoctors");

            migrationBuilder.AddColumn<Guid>(
                name: "TestResultId",
                table: "TestResultsPatients",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1376899d-8e75-4772-bdd9-48c3ebc1cd2e"), 2 },
                    { new Guid("297724c0-ff16-480e-978f-fb992a7ec5dd"), 1 },
                    { new Guid("5d848e25-240e-4938-927b-8fb45cd49914"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestResultsPatients_TestResultId",
                table: "TestResultsPatients",
                column: "TestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctors_DoctorsId",
                table: "PatientDoctors",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctors_PatientsId",
                table: "PatientDoctors",
                column: "PatientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Users_DoctorsId",
                table: "PatientDoctors",
                column: "DoctorsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Users_PatientsId",
                table: "PatientDoctors",
                column: "PatientsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResultsPatients_TestResults_TestResultId",
                table: "TestResultsPatients",
                column: "TestResultId",
                principalTable: "TestResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Users_DoctorsId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Users_PatientsId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResultsPatients_TestResults_TestResultId",
                table: "TestResultsPatients");

            migrationBuilder.DropIndex(
                name: "IX_TestResultsPatients_TestResultId",
                table: "TestResultsPatients");

            migrationBuilder.DropIndex(
                name: "IX_PatientDoctors_DoctorsId",
                table: "PatientDoctors");

            migrationBuilder.DropIndex(
                name: "IX_PatientDoctors_PatientsId",
                table: "PatientDoctors");

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

            migrationBuilder.DropColumn(
                name: "TestResultId",
                table: "TestResultsPatients");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "PatientDoctors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "PatientDoctors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_PatientDoctors_DoctorId",
                table: "PatientDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctors_PatientId",
                table: "PatientDoctors",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Users_DoctorId",
                table: "PatientDoctors",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Users_PatientId",
                table: "PatientDoctors",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
