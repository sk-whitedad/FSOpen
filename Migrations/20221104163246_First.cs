using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingSizes.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoordForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormName = table.Column<string>(type: "TEXT", nullable: true),
                    Coord_X = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 100),
                    Coord_Y = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 100),
                    Widht = table.Column<int>(type: "INTEGER", nullable: false),
                    Hight = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimePrint = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Exchange = table.Column<string>(type: "TEXT", nullable: true),
                    Vol = table.Column<int>(type: "INTEGER", nullable: false),
                    Flag = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prints", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoordForms");

            migrationBuilder.DropTable(
                name: "Prints");
        }
    }
}
