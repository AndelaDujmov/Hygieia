using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManyUsersToVaccinationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients");

            migrationBuilder.DropIndex(
                name: "IX_ImmunizationPatients_UserId",
                table: "ImmunizationPatients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ImmunizationPatients");

            migrationBuilder.AddColumn<Guid>(
                name: "ImmunizationPatientId",
                table: "AspNetUsers",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImmunizationPatientId",
                table: "AspNetUsers",
                column: "ImmunizationPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ImmunizationPatients_ImmunizationPatientId",
                table: "AspNetUsers",
                column: "ImmunizationPatientId",
                principalTable: "ImmunizationPatients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImmunizationPatients_ImmunizationPatientId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImmunizationPatientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImmunizationPatientId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ImmunizationPatients",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationPatients_UserId",
                table: "ImmunizationPatients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
