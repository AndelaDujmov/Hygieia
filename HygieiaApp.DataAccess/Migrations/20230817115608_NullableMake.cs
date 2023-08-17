using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NullableMake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_AspNetUsers_UserId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_MedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PatientMedicalConditions",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalConditionId",
                table: "PatientMedicalConditions",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalConditions_AspNetUsers_UserId",
                table: "PatientMedicalConditions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalConditions_MedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions",
                column: "MedicalConditionId",
                principalTable: "MedicalConditions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_AspNetUsers_UserId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_MedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PatientMedicalConditions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalConditionId",
                table: "PatientMedicalConditions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalConditions_AspNetUsers_UserId",
                table: "PatientMedicalConditions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalConditions_MedicalConditions_MedicalConditionId",
                table: "PatientMedicalConditions",
                column: "MedicalConditionId",
                principalTable: "MedicalConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
