using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DoctorAndPtentNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_AspNetUsers_DoctorId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_AspNetUsers_PatientId",
                table: "Schedulers");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Schedulers",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Schedulers",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_AspNetUsers_DoctorId",
                table: "Schedulers",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_AspNetUsers_PatientId",
                table: "Schedulers",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_AspNetUsers_DoctorId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_AspNetUsers_PatientId",
                table: "Schedulers");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Schedulers",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Schedulers",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_AspNetUsers_DoctorId",
                table: "Schedulers",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_AspNetUsers_PatientId",
                table: "Schedulers",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
