using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Position", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9828), null, "email@gmail.com", "Umidjon", false, "Maxammadsoliyev", "Password", "Dentist", null },
                    { 2L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9832), null, "email@gmail.com", "Odiljon", false, "Maxammadsoliyev", "Password", "Dentist", null },
                    { 3L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9833), null, "email@gmail.com", "Valijon", false, "Maxammadsoliyev", "Password", "Dentist", null }
                });

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreatedAt", "DateTime", "DeletedAt", "DoctorId", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9849), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9850), null, 1L, false, null, 1L },
                    { 2L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9851), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9851), null, 2L, false, null, 2L },
                    { 3L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9852), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9852), null, 3L, false, null, 3L }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "CreatedAt", "DateTime", "DeletedAt", "DoctorId", "IsDeleted", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9868), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9871), null, 1L, false, null, 1L },
                    { 2L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9871), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9872), null, 3L, false, null, 2L }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionItems",
                columns: new[] { "Id", "CreatedAt", "Days", "DeletedAt", "IsDeleted", "MedicineName", "MedicineUsage", "PrescriptionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9891), 11, null, false, "Dori", "Ichiladi", 1L, null },
                    { 2L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9893), 11, null, false, "sdsds", "sdsd", 1L, null },
                    { 3L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9894), 11, null, false, "Dori", "Ichiladi", 2L, null },
                    { 4L, new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9895), 11, null, false, "DoriDarmon", "Ichiladi", 2L, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 38, 52, 809, DateTimeKind.Utc).AddTicks(6330));
        }
    }
}
