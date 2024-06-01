using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(324), new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(325) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(326), new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(327) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(328), new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(345), new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(347) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(349), new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(349) });

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "UserContacts",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 9, 32, 59, 9, DateTimeKind.Utc).AddTicks(90));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9849), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9851), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9851) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9852), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "PrescriptionItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9868), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9871) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "DateTime" },
                values: new object[] { new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9871), new DateTime(2024, 5, 17, 4, 52, 33, 323, DateTimeKind.Utc).AddTicks(9872) });

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
        }
    }
}
