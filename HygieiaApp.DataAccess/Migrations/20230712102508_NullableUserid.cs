using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NullableUserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_Immunizations_ImmunizationId",
                table: "ImmunizationPatients");

            migrationBuilder.AlterColumn<string>(
                name: "Results",
                table: "TestResultsPatients",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ImmunizationPatients",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImmunizationId",
                table: "ImmunizationPatients",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_Immunizations_ImmunizationId",
                table: "ImmunizationPatients",
                column: "ImmunizationId",
                principalTable: "Immunizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_Immunizations_ImmunizationId",
                table: "ImmunizationPatients");

            migrationBuilder.AlterColumn<string>(
                name: "Results",
                table: "TestResultsPatients",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ImmunizationPatients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImmunizationId",
                table: "ImmunizationPatients",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_Immunizations_ImmunizationId",
                table: "ImmunizationPatients",
                column: "ImmunizationId",
                principalTable: "Immunizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
