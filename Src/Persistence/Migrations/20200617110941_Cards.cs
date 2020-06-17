using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Cards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trinkets",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ClassType",
                table: "Trinkets",
                nullable: false,
                defaultValue: "Any",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Trinkets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Effect",
                table: "Trinkets",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EffectPower",
                table: "Trinkets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Trinkets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Relics",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Effect",
                table: "Relics",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassType",
                table: "Relics",
                nullable: false,
                defaultValue: "Any",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Relics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CardCount",
                table: "Equipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Consumeables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Effect",
                table: "Consumeables",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EffectPower",
                table: "Consumeables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Stat",
                table: "Consumeables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZoneName",
                table: "Consumeables",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slot = table.Column<string>(maxLength: 30, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(nullable: false, defaultValue: "Any"),
                    Effect = table.Column<string>(maxLength: 50, nullable: false),
                    EffectPower = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsPositive = table.Column<bool>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    MaterialType = table.Column<string>(maxLength: 30, nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardsEquipment",
                columns: table => new
                {
                    CardId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsEquipment", x => new { x.CardId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_CardsEquipment_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardsEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardsInventories",
                columns: table => new
                {
                    CardId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsInventories", x => new { x.CardId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_CardsInventories_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardsInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardsEquipment_EquipmentId",
                table: "CardsEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsInventories_InventoryId",
                table: "CardsInventories",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardsEquipment");

            migrationBuilder.DropTable(
                name: "CardsInventories");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Trinkets");

            migrationBuilder.DropColumn(
                name: "Effect",
                table: "Trinkets");

            migrationBuilder.DropColumn(
                name: "EffectPower",
                table: "Trinkets");

            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Trinkets");

            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Relics");

            migrationBuilder.DropColumn(
                name: "CardCount",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "Effect",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "EffectPower",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "Stat",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "ZoneName",
                table: "Consumeables");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trinkets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ClassType",
                table: "Trinkets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldDefaultValue: "Any");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Relics",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Effect",
                table: "Relics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ClassType",
                table: "Relics",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "Any");
        }
    }
}
