using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingSizes.Migrations
{
    public partial class Upd03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Prints",
                type: "REAL",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Prints");
        }
    }
}
