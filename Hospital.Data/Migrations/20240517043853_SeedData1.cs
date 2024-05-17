using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsDeleted", "LastName", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6326), null, "Valijonov@gmail.com", "Ali", false, "Valiyev", "Password", null },
                    { 3L, new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6329), null, "Valijonov@gmail.com", "Ali", false, "Valiyev", "Password", null },
                    { 4L, new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6330), null, "Valijonov@gmail.com", "Ali", false, "Valiyev", "Password", null }
                });

            migrationBuilder.InsertData(
                table: "UserContacts",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "IsDeleted", "Phone", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, "Andijon Shahri", new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6562), null, false, "+9989901233567", null, 3L },
                    { 2L, "Qarshi Shahri", new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6567), null, false, "+9989901234567", null, 4L },
                    { 3L, "Toshkent Shahri", new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6582), null, false, "+9989901234567", null, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 25, 48, 539, DateTimeKind.Utc).AddTicks(8958));
        }
    }
}
