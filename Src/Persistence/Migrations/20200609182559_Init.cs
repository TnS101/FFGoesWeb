using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Relics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Effect = table.Column<string>(nullable: true),
                    EffectPower = table.Column<double>(nullable: false),
                    Slot = table.Column<string>(maxLength: 30, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(maxLength: 30, nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Intellect = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Spirit = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    BuyPrice = table.Column<int>(nullable: false),
                    SellPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelicsEquipments",
                columns: table => new
                {
                    RelicId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelicsEquipments", x => new { x.RelicId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_RelicsEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelicsEquipments_Relics_RelicId",
                        column: x => x.RelicId,
                        principalTable: "Relics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelicsInventories",
                columns: table => new
                {
                    RelicId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelicsInventories", x => new { x.RelicId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_RelicsInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelicsInventories_Relics_RelicId",
                        column: x => x.RelicId,
                        principalTable: "Relics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelicsEquipments_EquipmentId",
                table: "RelicsEquipments",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RelicsInventories_InventoryId",
                table: "RelicsInventories",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorsEquipments");

            migrationBuilder.DropTable(
                name: "ArmorsInventories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConsumeableInventory");

            migrationBuilder.DropTable(
                name: "EnergyChanges");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "MaterialsInventories");

            migrationBuilder.DropTable(
                name: "MonstersRarities");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RelicsEquipments");

            migrationBuilder.DropTable(
                name: "RelicsInventories");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ToolsInventories");

            migrationBuilder.DropTable(
                name: "TreasureKeysInventories");

            migrationBuilder.DropTable(
                name: "TreasuresInventories");

            migrationBuilder.DropTable(
                name: "TrinketEquipments");

            migrationBuilder.DropTable(
                name: "TrinketsInventories");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "WeaponsEquipments");

            migrationBuilder.DropTable(
                name: "WeaponsInventories");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Consumeables");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Relics");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "TreasureKeys");

            migrationBuilder.DropTable(
                name: "Treasures");

            migrationBuilder.DropTable(
                name: "Trinkets");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "FightingClasses");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
