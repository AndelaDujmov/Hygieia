using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManyUsersToVaccinationDateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImmunizationPatients_ImmunizationPatientId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ImmunizationPatients_ImmunizationPatientId",
                table: "AspNetUsers",
                column: "ImmunizationPatientId",
                principalTable: "ImmunizationPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImmunizationPatients_ImmunizationPatientId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ImmunizationPatients_ImmunizationPatientId",
                table: "AspNetUsers",
                column: "ImmunizationPatientId",
                principalTable: "ImmunizationPatients",
                principalColumn: "Id");
        }
    }
}
