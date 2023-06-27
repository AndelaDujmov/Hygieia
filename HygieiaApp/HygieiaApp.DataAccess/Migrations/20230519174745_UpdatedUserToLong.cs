using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HygieiaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserToLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("24a3c346-58b7-4015-a27c-1d9ffaa31f55"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f7ca601-5129-4be5-bb47-ed3358e35d13"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a10bbb6c-332c-4354-9b4f-b81e94efa667"));

            migrationBuilder.AlterColumn<long>(
                name: "OIB",
                table: "Users",
                type: "bigint",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<long>(
                name: "MBO",
                table: "Users",
                type: "bigint",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("19d7509f-d5ab-4f56-afb1-5b1e4b4bd810"), 1 },
                    { new Guid("8203f3a3-ad8f-402b-80bc-a9be6ed40695"), 2 },
                    { new Guid("a08e72cd-11d6-4d4a-8037-d8d2867d13da"), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("19d7509f-d5ab-4f56-afb1-5b1e4b4bd810"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8203f3a3-ad8f-402b-80bc-a9be6ed40695"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a08e72cd-11d6-4d4a-8037-d8d2867d13da"));

            migrationBuilder.AlterColumn<int>(
                name: "OIB",
                table: "Users",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "MBO",
                table: "Users",
                type: "int",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 9);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24a3c346-58b7-4015-a27c-1d9ffaa31f55"), 1 },
                    { new Guid("8f7ca601-5129-4be5-bb47-ed3358e35d13"), 2 },
                    { new Guid("a10bbb6c-332c-4354-9b4f-b81e94efa667"), 0 }
                });
        }
    }
}
