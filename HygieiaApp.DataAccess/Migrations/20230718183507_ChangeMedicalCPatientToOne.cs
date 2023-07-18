using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMedicalCPatientToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalConditions_PatientMedicalConditions_PatientMedicalCon~",
                table: "MedicalConditions");

            migrationBuilder.DropIndex(
                name: "IX_MedicalConditions_PatientMedicalConditionId",
                table: "MedicalConditions");

            migrationBuilder.DropColumn(
                name: "PatientMedicalConditionId",
                table: "MedicalConditions");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalConditionId",
                table: "PatientMedicalConditions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions",
                column: "MedicalConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalConditions_MedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions",
                column: "MedicalConditionId",
                principalTable: "MedicalConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_MedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropColumn(
                name: "MedicalConditionId",
                table: "PatientMedicalConditions");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientMedicalConditionId",
                table: "MedicalConditions",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConditions_PatientMedicalConditionId",
                table: "MedicalConditions",
                column: "PatientMedicalConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalConditions_PatientMedicalConditions_PatientMedicalCon~",
                table: "MedicalConditions",
                column: "PatientMedicalConditionId",
                principalTable: "PatientMedicalConditions",
                principalColumn: "Id");
        }
    }
}
