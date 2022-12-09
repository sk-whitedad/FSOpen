using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingSizes.Migrations
{
    public partial class Upd02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ticker",
                table: "Prints",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticker",
                table: "Prints");
        }
    }
}
