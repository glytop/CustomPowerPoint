using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomPowerPoint.Data.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPresentationRoles_Presentations_PresentationDataId",
                table: "UserPresentationRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserPresentationRoles_PresentationDataId",
                table: "UserPresentationRoles");

            migrationBuilder.DropColumn(
                name: "PresentationDataId",
                table: "UserPresentationRoles");

            migrationBuilder.CreateTable(
                name: "PresentationUsers",
                columns: table => new
                {
                    PresentationDataId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationUsers", x => new { x.PresentationDataId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PresentationUsers_Presentations_PresentationDataId",
                        column: x => x.PresentationDataId,
                        principalTable: "Presentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentationUsers_UserPresentationRoles_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UserPresentationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresentationUsers_UsersId",
                table: "PresentationUsers",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentationUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "PresentationDataId",
                table: "UserPresentationRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPresentationRoles_PresentationDataId",
                table: "UserPresentationRoles",
                column: "PresentationDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPresentationRoles_Presentations_PresentationDataId",
                table: "UserPresentationRoles",
                column: "PresentationDataId",
                principalTable: "Presentations",
                principalColumn: "Id");
        }
    }
}
