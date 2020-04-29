using Application.GameCQ.Items.Commands.Delete;
using Application.Tests.Infrastructure;
using Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Items.Commands
{
    public class DiscardItemCommandHandlerTests : CommandTestBase
    {
        private readonly string heroId;
        private readonly DiscardItemCommandHandler sut;

        public DiscardItemCommandHandlerTests()
        {
            QueryArrangeHelper.AddArmors(context);
            QueryArrangeHelper.AddWeapons(context);
            QueryArrangeHelper.AddTrinkets(context);
            QueryArrangeHelper.AddTools(context);
            QueryArrangeHelper.AddMaterials(context);
            QueryArrangeHelper.AddTreasures(context);
            QueryArrangeHelper.AddTreasureKeys(context);

            QueryArrangeHelper.AddArmorInventory(context);
            QueryArrangeHelper.AddWeaponInventory(context);
            QueryArrangeHelper.AddTrinketInventory(context);
            QueryArrangeHelper.AddToolInventory(context);
            QueryArrangeHelper.AddMaterialInventory(context);
            QueryArrangeHelper.AddTreasureInventory(context);
            QueryArrangeHelper.AddTreasureKeyInventory(context);

            this.heroId = CommandArrangeHelper.GetHeroId(context);
            this.sut = new DiscardItemCommandHandler(context);
        }

        [Fact]
        public async Task ShouldDiscardItem()
        {
            await this.Result("Weapon", 1, "1");
            await this.Result("Armor", 1, "1");
            await this.Result("Trinket", 1, "1");
            await this.Result("Tool", 1, "1");
            await this.Result("Material", 1, "1");
            await this.Result("Treasure", 1, "1");
            await this.Result("Treasure Key", 1, "1");

            await this.Result("Weapon", 2, "1");
            await this.Result("Armor", 2, "1");
            await this.Result("Trinket", 2, "1");
            await this.Result("Tool", 2, "1");
            await this.Result("Material", 2, "1");
            await this.Result("Treasure", 2, "1");
            await this.Result("Treasure Key", 2, "1");
        }

        private async Task Result(string slot, int count, string itemId)
        {
            var result = await this.sut.Handle(new DiscardItemCommand { HeroId = this.heroId, ItemId = itemId, Slot = slot, Count = count }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.InventoryCommandRedirect, this.heroId, slot));

            if (count > 1)
            {
                if (slot == "Weapon")
                {
                    this.context.WeaponsInventories.Count().ShouldBe(0);
                }

                if (slot == "Trinket")
                {
                    this.context.TrinketsInventories.Count().ShouldBe(0);
                }

                if (slot == "Armor")
                {
                    this.context.ArmorsInventories.Count().ShouldBe(0);
                }

                if (slot == "Tool")
                {
                    this.context.ToolsInventories.Count().ShouldBe(0);
                }

                if (slot == "Material")
                {
                    this.context.MaterialsInventories.Count().ShouldBe(0);
                }

                if (slot == "Treasure")
                {
                    this.context.TreasuresInventories.Count().ShouldBe(0);
                }

                if (slot == "Treasure Key")
                {
                    this.context.TreasureKeysInventories.Count().ShouldBe(0);
                }
            }
            else if (count == 1)
            {
                if (slot == "Weapon")
                {
                    this.context.WeaponsInventories.Count().ShouldBe(1);

                    var inventory = this.context.WeaponsInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }

                if (slot == "Trinket")
                {
                    this.context.TrinketsInventories.Count().ShouldBe(1);

                    var inventory = this.context.TrinketsInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }

                if (slot == "Armor")
                {
                    this.context.ArmorsInventories.Count().ShouldBe(1);

                    var inventory = this.context.ArmorsInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }

                if (slot == "Tool")
                {
                    this.context.ToolsInventories.Count().ShouldBe(1);

                    var inventory = this.context.ToolsInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }

                if (slot == "Material")
                {
                    this.context.MaterialsInventories.Count().ShouldBe(1);

                    var inventory = this.context.MaterialsInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }

                if (slot == "Treasure")
                {
                    this.context.TreasuresInventories.Count().ShouldBe(1);

                    var inventory = this.context.TreasuresInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }

                if (slot == "Treasure Key")
                {
                    this.context.TreasureKeysInventories.Count().ShouldBe(1);

                    var inventory = this.context.TreasureKeysInventories.FirstOrDefault();

                    inventory.Count.ShouldBe(1);
                }
            }
        }
    }
}
