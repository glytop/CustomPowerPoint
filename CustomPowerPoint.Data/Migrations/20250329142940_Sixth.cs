using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomPowerPoint.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elements",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SlideElements");

            migrationBuilder.AddColumn<Guid>(
                name: "SlideDataId",
                table: "SlideElements",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlideElements_SlideDataId",
                table: "SlideElements",
                column: "SlideDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideElements_Slides_SlideDataId",
                table: "SlideElements",
                column: "SlideDataId",
                principalTable: "Slides",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideElements_Slides_SlideDataId",
                table: "SlideElements");

            migrationBuilder.DropIndex(
                name: "IX_SlideElements_SlideDataId",
                table: "SlideElements");

            migrationBuilder.DropColumn(
                name: "SlideDataId",
                table: "SlideElements");

            migrationBuilder.AddColumn<int[]>(
                name: "Elements",
                table: "Slides",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "SlideElements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
