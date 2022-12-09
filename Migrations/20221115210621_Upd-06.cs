using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingSizes.Migrations
{
    public partial class Upd06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CoordForms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CoordForms_UserId",
                table: "CoordForms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordForms_Users_UserId",
                table: "CoordForms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordForms_Users_UserId",
                table: "CoordForms");

            migrationBuilder.DropIndex(
                name: "IX_CoordForms_UserId",
                table: "CoordForms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoordForms");
        }
    }
}
