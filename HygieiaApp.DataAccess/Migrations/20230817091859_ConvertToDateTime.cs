using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConvertToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfDiagnosis",
                table: "PatientMedicalConditions",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfDiagnosis",
                table: "PatientMedicalConditions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
