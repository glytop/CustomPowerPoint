using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomPowerPoint.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresentationUsers_UserPresentationRoles_UsersId",
                table: "PresentationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPresentationRoles",
                table: "UserPresentationRoles");

            migrationBuilder.RenameTable(
                name: "UserPresentationRoles",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationUsers_Users_UsersId",
                table: "PresentationUsers",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresentationUsers_Users_UsersId",
                table: "PresentationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserPresentationRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPresentationRoles",
                table: "UserPresentationRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationUsers_UserPresentationRoles_UsersId",
                table: "PresentationUsers",
                column: "UsersId",
                principalTable: "UserPresentationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
