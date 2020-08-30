using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Redun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_MonstersRarities_MonsterRarityId1",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_MonsterRarityId1",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MonsterRarityId1",
                table: "Monsters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonsterRarityId1",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_MonsterRarityId1",
                table: "Monsters",
                column: "MonsterRarityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_MonstersRarities_MonsterRarityId1",
                table: "Monsters",
                column: "MonsterRarityId1",
                principalTable: "MonstersRarities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
