using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CardEquipmentCount1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "CardsEquipments");

            migrationBuilder.AddColumn<int>(
                name: "CardSlots",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardSlots",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "CardsEquipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
