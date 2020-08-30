using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class NameConv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZoneName",
                table: "Consumeables");

            migrationBuilder.AddColumn<string>(
                name: "DroppedFrom",
                table: "Consumeables",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DroppedFrom",
                table: "Consumeables");

            migrationBuilder.AddColumn<string>(
                name: "ZoneName",
                table: "Consumeables",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
