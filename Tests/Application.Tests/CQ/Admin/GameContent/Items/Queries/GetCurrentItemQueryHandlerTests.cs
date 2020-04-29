namespace Application.Tests.CQ.Admin.GameContent.Items.Queries
{
    using Application.CQ.Admin.GameContent.Items.Queries.GetCurrentItemQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetCurrentItemQueryHandlerTests : QueryTestFixture
    {
        private GetCurrentItemQueryHandler sut;

        public GetCurrentItemQueryHandlerTests()
        {
            this.sut = new GetCurrentItemQueryHandler(context);
        }

        [Fact]
        public async Task ShouldReturnCurrentItemById()
        {
            int materialId = CommandArrangeHelper.GetMaterialId(context);
            int toolId = CommandArrangeHelper.GetToolId(context);
            string weaponId = CommandArrangeHelper.GetWeaponId(context);
            string armorId = CommandArrangeHelper.GetArmorId(context);
            string trinketId = CommandArrangeHelper.GetTrinketId(context);
            int tresureId = CommandArrangeHelper.GetTreasureId(context);
            int treasurekeyId = CommandArrangeHelper.GetTreasureKeyId(context);

            await this.Result(materialId.ToString(), "Material");
            await this.Result(toolId.ToString(), "Tool");
            await this.Result(treasurekeyId.ToString(), "Treasure Key");
            await this.Result(tresureId.ToString(), "Treasure");
            await this.Result(weaponId, "Weapon");
            await this.Result(armorId, "Chestplate");
            await this.Result(trinketId, "Trinket");
        }

        public async Task Result(string itemId, string slot)
        {
            var result = await this.sut.Handle(new GetCurrentItemQuery { ItemId = itemId, Slot = slot }, CancellationToken.None);

            result.ShouldBeOfType<ItemFullViewModel>();

            if (slot == "Weapon")
            {
                result.Agility.ShouldBe(1);
                result.Spirit.ShouldBe(1);
                result.Stamina.ShouldBe(1);
                result.Strength.ShouldBe(1);
                result.Intellect.ShouldBe(1);
                result.Level.ShouldBe(1);
                result.ClassType.ShouldBe("1");
                result.AttackPower.ShouldBe(10);
                result.Id.ShouldNotBeNull();
                result.BuyPrice.ShouldBe(10);
                result.SellPrice.ShouldBe(10);
                result.Name.ShouldBe("1");
                result.Slot.ShouldBe("Weapon");
                result.ImagePath.ShouldNotBeNull();
                result.IsCraftable.ShouldNotBeNull();
            }
            else if (slot == "Trinket")
            {
                result.Agility.ShouldBe(1);
                result.Spirit.ShouldBe(1);
                result.Stamina.ShouldBe(1);
                result.Strength.ShouldBe(1);
                result.Intellect.ShouldBe(1);
                result.Level.ShouldBe(1);
                result.ClassType.ShouldBe("1");
                result.Id.ShouldNotBeNull();
                result.BuyPrice.ShouldBe(10);
                result.SellPrice.ShouldBe(10);
                result.Name.ShouldBe("1");
                result.Slot.ShouldBe("Trinket");
                result.ImagePath.ShouldNotBeNull();
                result.IsCraftable.ShouldNotBeNull();
            }
            else if (slot == "Tool")
            {
                result.ImagePath.ShouldNotBeNull();
                result.Name.ShouldBe("1");
                result.SellPrice.ShouldBe(10);
                result.BuyPrice.ShouldBe(10);
                result.Slot.ShouldBe("Tool");
                result.Durability.ShouldBe(1);
                result.IsCraftable.ShouldNotBeNull();
            }
            else if (slot == "Material")
            {
                result.ImagePath.ShouldNotBeNull();
                result.Name.ShouldBe("1");
                result.SellPrice.ShouldBe(10);
                result.BuyPrice.ShouldBe(10);
                result.Slot.ShouldBe("Material");
                result.IsCraftable.ShouldNotBeNull();
                result.FuelCount.ShouldBe(1);
                result.RelatedMaterials.ShouldBe("1");
                result.IsCraftable.ShouldNotBeNull();
                result.IsDisolveable.ShouldNotBeNull();
                result.IsRefineable.ShouldNotBeNull();
                result.MaterialType.ShouldBe("1");
                result.ToolName.ShouldBe("1");
            }
            else if (slot == "Treasure")
            {
                result.Name.ShouldBe("1");
                result.ImagePath.ShouldNotBeNull();
                result.Rarity.ShouldBe("1");
                result.Slot.ShouldBe("Treasure");
                result.Reward.ShouldBe(10);
            }
            else if (slot == "Treasure Key")
            {
                result.Name.ShouldBe("1");
                result.ImagePath.ShouldNotBeNull();
                result.Rarity.ShouldBe("1");
                result.Slot.ShouldBe("Treasure Key");
            }
            else
            {
                result.Agility.ShouldBe(1);
                result.Spirit.ShouldBe(1);
                result.Stamina.ShouldBe(1);
                result.Strength.ShouldBe(1);
                result.Intellect.ShouldBe(1);
                result.Level.ShouldBe(1);
                result.ClassType.ShouldBe("1");
                result.Id.ShouldNotBeNull();
                result.BuyPrice.ShouldBe(10);
                result.SellPrice.ShouldBe(10);
                result.Name.ShouldBe("1");
                result.Slot.ShouldBe("Chestplate");
                result.ArmorValue.ShouldBe(1);
                result.ResistanceValue.ShouldBe(1);
                result.ImagePath.ShouldNotBeNull();
                result.IsCraftable.ShouldNotBeNull();
            }
        }
    }
}
