namespace Application.Tests.CQ.Admin.GameContent.Items.Commands
{
    using Application.CQ.Admin.GameContent.Items.Commands.Delete;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteItemCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteItemCommandHandler sut;

        public DeleteItemCommandHandlerTests()
        {
            this.sut = new DeleteItemCommandHandler(context);
            QueryArrangeHelper.AddEquipments(context);
            QueryArrangeHelper.AddInventory(context);
        }

        [Fact]
        public async Task ShouldDeleteItem()
        {
            int materialId = CommandArrangeHelper.GetMaterialId(context);
            int toolId = CommandArrangeHelper.GetToolId(context);
            string weaponId = CommandArrangeHelper.GetWeaponId(context);
            string armorId = CommandArrangeHelper.GetArmorId(context);
            string trinketId = CommandArrangeHelper.GetTrinketId(context);
            int tresureId = CommandArrangeHelper.GetTreasureId(context);
            int treasurekeyId = CommandArrangeHelper.GetTreasureKeyId(context);

            await this.Result(weaponId, "Weapon");
            await this.Result(materialId.ToString(), "Material");
            await this.Result(toolId.ToString(), "Tool");
            await this.Result(treasurekeyId.ToString(), "Treasure Key");
            await this.Result(tresureId.ToString(), "Treasure");
            await this.Result(armorId, "Armor");
            await this.Result(trinketId, "Trinket");

        }

        private async Task Result(string itemId, string slot)
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new DeleteItemCommand { ItemId = itemId, Slot = slot }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(string.Format(GConst.AdminItemCommandRedirect, slot));

            if (slot == "Weapon")
            {

                context.WeaponsEquipments.Count().ShouldBe(0);
                context.WeaponsInventories.Count().ShouldBe(0);
                context.Weapons.Count().ShouldBe(0);
            }

            if (slot == "Trinket")
            {

                context.Trinkets.Count().ShouldBe(0);
                context.TrinketsInventories.Count().ShouldBe(0);
                context.TrinketEquipments.Count().ShouldBe(0);
            }

             if (slot == "Tool")
            {
                context.Tools.Count().ShouldBe(0);
                context.ToolsInventories.Count().ShouldBe(0);

            }

             if (slot == "Material")
            {
                context.Materials.Count().ShouldBe(0);
                context.MaterialsInventories.Count().ShouldBe(0);
            }

             if (slot == "Treasure")
            {
                context.Treasures.Count().ShouldBe(0);
                context.TreasuresInventories.Count().ShouldBe(0);
            }

             if (slot == "Treasure Key")
            {
                context.TreasureKeys.Count().ShouldBe(0);
                context.TreasureKeysInventories.Count().ShouldBe(0);
            }

            if (slot == "Armor")
            {
                context.Armors.Count().ShouldBe(0);
                context.ArmorsInventories.Count().ShouldBe(0);
                context.ArmorsEquipments.Count().ShouldBe(0);
            }
        }
    }
}
