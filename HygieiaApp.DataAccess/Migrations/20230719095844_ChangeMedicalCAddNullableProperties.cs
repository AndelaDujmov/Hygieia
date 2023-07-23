using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMedicalCAddNullableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalConditionMedicateds_MedicalConditionMedications_Medic~",
                table: "MedicalConditionMedicateds");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalConditionMedicateds_PatientMedicalConditions_MedicalC~",
                table: "MedicalConditionMedicateds");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalConditionPatientId",
                table: "MedicalConditionMedicateds",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalConditionMedicationId",
                table: "MedicalConditionMedicateds",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalConditionMedicateds_MedicalConditionMedications_Medic~",
                table: "MedicalConditionMedicateds",
                column: "MedicalConditionMedicationId",
                principalTable: "MedicalConditionMedications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalConditionMedicateds_PatientMedicalConditions_MedicalC~",
                table: "MedicalConditionMedicateds",
                column: "MedicalConditionPatientId",
                principalTable: "PatientMedicalConditions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalConditionMedicateds_MedicalConditionMedications_Medic~",
                table: "MedicalConditionMedicateds");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalConditionMedicateds_PatientMedicalConditions_MedicalC~",
                table: "MedicalConditionMedicateds");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalConditionPatientId",
                table: "MedicalConditionMedicateds",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalConditionMedicationId",
                table: "MedicalConditionMedicateds",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalConditionMedicateds_MedicalConditionMedications_Medic~",
                table: "MedicalConditionMedicateds",
                column: "MedicalConditionMedicationId",
                principalTable: "MedicalConditionMedications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalConditionMedicateds_PatientMedicalConditions_MedicalC~",
                table: "MedicalConditionMedicateds",
                column: "MedicalConditionPatientId",
                principalTable: "PatientMedicalConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
