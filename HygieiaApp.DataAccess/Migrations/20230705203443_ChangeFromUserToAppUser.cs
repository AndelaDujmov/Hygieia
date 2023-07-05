using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFromUserToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_Users_UserId",
                table: "ImmunizationPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Users_DoctorsId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Users_PatientsId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_Users_PatientId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Users_DoctorId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Users_PatientId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResultsPatients_Users_PatientId",
                table: "TestResultsPatients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalConditions_PatientId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientMedicalConditions");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "TestResultsPatients",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Schedulers",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Schedulers",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PatientMedicalConditions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PatientsId",
                table: "PatientDoctors",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorsId",
                table: "PatientDoctors",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ImmunizationPatients",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalConditions_UserId",
                table: "PatientMedicalConditions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_AspNetUsers_DoctorsId",
                table: "PatientDoctors",
                column: "DoctorsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_AspNetUsers_PatientsId",
                table: "PatientDoctors",
                column: "PatientsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalConditions_AspNetUsers_UserId",
                table: "PatientMedicalConditions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestResultsPatients_AspNetUsers_PatientId",
                table: "TestResultsPatients",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImmunizationPatients_AspNetUsers_UserId",
                table: "ImmunizationPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_AspNetUsers_DoctorsId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_AspNetUsers_PatientsId",
                table: "PatientDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalConditions_AspNetUsers_UserId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_AspNetUsers_DoctorId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_AspNetUsers_PatientId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResultsPatients_AspNetUsers_PatientId",
                table: "TestResultsPatients");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalConditions_UserId",
                table: "PatientMedicalConditions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PatientMedicalConditions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "TestResultsPatients",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Schedulers",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Schedulers",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "PatientMedicalConditions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientsId",
                table: "PatientDoctors",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorsId",
                table: "PatientDoctors",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ImmunizationPatients",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    MBO = table.Column<long>(type: "bigint", maxLength: 9, nullable: false),
                    OIB = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalConditions_PatientId",
                table: "PatientMedicalConditions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImmunizationPatients_Users_UserId",
                table: "ImmunizationPatients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_PatientMedicalConditions_Users_PatientId",
                table: "PatientMedicalConditions",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Users_DoctorId",
                table: "Schedulers",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Users_PatientId",
                table: "Schedulers",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResultsPatients_Users_PatientId",
                table: "TestResultsPatients",
                column: "PatientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
