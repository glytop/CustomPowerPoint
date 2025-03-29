using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomPowerPoint.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slides",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "Users",
                table: "Presentations");

            migrationBuilder.AddColumn<Guid>(
                name: "PresentationDataId",
                table: "UserPresentationRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PresentationDataId",
                table: "Slides",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPresentationRoles_PresentationDataId",
                table: "UserPresentationRoles",
                column: "PresentationDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_PresentationDataId",
                table: "Slides",
                column: "PresentationDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Presentations_PresentationDataId",
                table: "Slides",
                column: "PresentationDataId",
                principalTable: "Presentations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPresentationRoles_Presentations_PresentationDataId",
                table: "UserPresentationRoles",
                column: "PresentationDataId",
                principalTable: "Presentations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Presentations_PresentationDataId",
                table: "Slides");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPresentationRoles_Presentations_PresentationDataId",
                table: "UserPresentationRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserPresentationRoles_PresentationDataId",
                table: "UserPresentationRoles");

            migrationBuilder.DropIndex(
                name: "IX_Slides_PresentationDataId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "PresentationDataId",
                table: "UserPresentationRoles");

            migrationBuilder.DropColumn(
                name: "PresentationDataId",
                table: "Slides");

            migrationBuilder.AddColumn<int[]>(
                name: "Slides",
                table: "Presentations",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<int[]>(
                name: "Users",
                table: "Presentations",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);
        }
    }
}
