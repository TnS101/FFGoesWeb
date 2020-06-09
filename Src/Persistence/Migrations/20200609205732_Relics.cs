using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Relics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Trinkets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Relics");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Armors");

            migrationBuilder.AddColumn<string>(
                name: "MaterialType",
                table: "Weapons",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialType",
                table: "Trinkets",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialType",
                table: "Relics",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Equipments",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 9);

            migrationBuilder.AddColumn<bool>(
                name: "RelicSlot",
                table: "Equipments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequiredItemType",
                table: "Consumeables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialType",
                table: "Armors",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialType",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "MaterialType",
                table: "Trinkets");

            migrationBuilder.DropColumn(
                name: "MaterialType",
                table: "Relics");

            migrationBuilder.DropColumn(
                name: "RelicSlot",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "RequiredItemType",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "MaterialType",
                table: "Armors");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Weapons",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Trinkets",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Relics",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 9,
                oldClrType: typeof(int),
                oldDefaultValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Armors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
