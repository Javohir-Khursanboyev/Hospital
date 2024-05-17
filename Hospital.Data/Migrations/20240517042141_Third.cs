using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContact_Users_UserId",
                table: "UserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContact",
                table: "UserContact");

            migrationBuilder.RenameTable(
                name: "UserContact",
                newName: "UserContacts");

            migrationBuilder.RenameIndex(
                name: "IX_UserContact_UserId",
                table: "UserContacts",
                newName: "IX_UserContacts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContacts",
                table: "UserContacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContacts",
                table: "UserContacts");

            migrationBuilder.RenameTable(
                name: "UserContacts",
                newName: "UserContact");

            migrationBuilder.RenameIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContact",
                newName: "IX_UserContact_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContact",
                table: "UserContact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContact_Users_UserId",
                table: "UserContact",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
