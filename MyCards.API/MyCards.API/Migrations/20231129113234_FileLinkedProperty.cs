using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCards.API.Migrations
{
    public partial class FileLinkedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FileLinked",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileLinked",
                table: "Cards");
        }
    }
}
