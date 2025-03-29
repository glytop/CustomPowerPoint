using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomPowerPoint.Data.Migrations
{
    /// <inheritdoc />
    public partial class Forth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserPresentationRoles");

            migrationBuilder.RenameColumn(
                name: "CreatorNickname",
                table: "Presentations",
                newName: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Presentations",
                newName: "CreatorNickname");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "UserPresentationRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
