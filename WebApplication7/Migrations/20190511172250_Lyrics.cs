using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication7.Migrations
{
    public partial class Lyrics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Song");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Song",
                newName: "Lyrics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lyrics",
                table: "Song",
                newName: "Genre");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Song",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
