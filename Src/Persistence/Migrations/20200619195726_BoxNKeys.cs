using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class BoxNKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreasureKeysInventories");

            migrationBuilder.DropTable(
                name: "TreasuresInventories");

            migrationBuilder.DropTable(
                name: "TreasureKeys");

            migrationBuilder.DropTable(
                name: "Treasures");

            migrationBuilder.DropColumn(
                name: "GoldAmount",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "GoldAmount",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "RequiredItemType",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Cards");

            migrationBuilder.AlterColumn<double>(
                name: "EffectPower",
                table: "Trinkets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "RelicsInventories",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CoinAmount",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlinded",
                table: "Monsters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfused",
                table: "Monsters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProvoked",
                table: "Monsters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSilenced",
                table: "Monsters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStunned",
                table: "Monsters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Inventories",
                nullable: false,
                defaultValue: 100,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 50);

            migrationBuilder.AddColumn<int>(
                name: "CoinAmount",
                table: "Heroes",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.AddColumn<int>(
                name: "Happiness",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hunger",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlinded",
                table: "Heroes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfused",
                table: "Heroes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProvoked",
                table: "Heroes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSilenced",
                table: "Heroes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStunned",
                table: "Heroes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Thirst",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Equipments",
                nullable: false,
                defaultValue: 11,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10);

            migrationBuilder.AddColumn<int>(
                name: "HungerReplenish",
                table: "Consumeables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThirstReplenish",
                table: "Consumeables",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "EffectPower",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SpellId",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LootBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    RewardAmplifier = table.Column<int>(nullable: false),
                    RequiresKey = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Treasure")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LootKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Slot = table.Column<string>(nullable: true, defaultValue: "Treasure Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Charges = table.Column<int>(nullable: false),
                    HappinessReplenish = table.Column<int>(nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false),
                    IsCraftable = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Slot = table.Column<string>(nullable: false, defaultValue: "Toy")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LootBoxesInventories",
                columns: table => new
                {
                    LootBoxId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootBoxesInventories", x => new { x.LootBoxId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_LootBoxesInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LootBoxesInventories_LootBoxes_LootBoxId",
                        column: x => x.LootBoxId,
                        principalTable: "LootBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LootKeysInventories",
                columns: table => new
                {
                    LootKeyId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootKeysInventories", x => new { x.LootKeyId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_LootKeysInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LootKeysInventories_LootKeys_LootKeyId",
                        column: x => x.LootKeyId,
                        principalTable: "LootKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToyInventories",
                columns: table => new
                {
                    ToyId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyInventories", x => new { x.ToyId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_ToyInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToyInventories_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SpellId",
                table: "Cards",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_LootBoxesInventories_InventoryId",
                table: "LootBoxesInventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LootKeysInventories_InventoryId",
                table: "LootKeysInventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyInventories_InventoryId",
                table: "ToyInventories",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Spells_SpellId",
                table: "Cards",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Spells_SpellId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "LootBoxesInventories");

            migrationBuilder.DropTable(
                name: "LootKeysInventories");

            migrationBuilder.DropTable(
                name: "ToyInventories");

            migrationBuilder.DropTable(
                name: "LootBoxes");

            migrationBuilder.DropTable(
                name: "LootKeys");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropIndex(
                name: "IX_Cards_SpellId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CoinAmount",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IsBlinded",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IsConfused",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IsProvoked",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IsSilenced",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IsStunned",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "CoinAmount",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Happiness",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Hunger",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "IsBlinded",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "IsConfused",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "IsProvoked",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "IsSilenced",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "IsStunned",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Thirst",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "HungerReplenish",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "ThirstReplenish",
                table: "Consumeables");

            migrationBuilder.DropColumn(
                name: "SpellId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "EffectPower",
                table: "Trinkets",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "RelicsInventories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "GoldAmount",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 50,
                oldClrType: typeof(int),
                oldDefaultValue: 100);

            migrationBuilder.AddColumn<int>(
                name: "GoldAmount",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldDefaultValue: 11);

            migrationBuilder.AddColumn<string>(
                name: "RequiredItemType",
                table: "Consumeables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EffectPower",
                table: "Cards",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TreasureKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rarity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Treasure Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasureKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rarity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Reward = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Treasure")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreasureKeysInventories",
                columns: table => new
                {
                    TreasureKeyId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasureKeysInventories", x => new { x.TreasureKeyId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_TreasureKeysInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreasureKeysInventories_TreasureKeys_TreasureKeyId",
                        column: x => x.TreasureKeyId,
                        principalTable: "TreasureKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreasuresInventories",
                columns: table => new
                {
                    TreasureId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuresInventories", x => new { x.TreasureId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_TreasuresInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreasuresInventories_Treasures_TreasureId",
                        column: x => x.TreasureId,
                        principalTable: "Treasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreasureKeysInventories_InventoryId",
                table: "TreasureKeysInventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuresInventories_InventoryId",
                table: "TreasuresInventories",
                column: "InventoryId");
        }
    }
}
