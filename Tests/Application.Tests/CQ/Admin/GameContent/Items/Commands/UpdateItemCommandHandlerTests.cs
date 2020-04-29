namespace Application.Tests.CQ.Admin.GameContent.Items.Commands
{
    using Application.CQ.Admin.GameContent.Items.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateItemCommandHandlerTests : CommandTestBase
    {
        private UpdateItemCommandHandler sut;

        public UpdateItemCommandHandlerTests()
        {
            this.sut = new UpdateItemCommandHandler(context);
        }

        [Fact]
        public async Task ShouldUpdateItem()
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
            await this.Result(armorId, "Armor");
            await this.Result(trinketId, "Trinket");
        }

        private async Task Result(string id, string slot)
        {
            var result = await this.sut.Handle(new UpdateItemCommand { Id = id, Slot = slot,
            NewAgility = 1, NewMaterialDiversity = "1", NewArmorValue = 1, NewAttackPower = 1,
            NewSellPrice = 1, NewBuyPrice = 1, NewClassType = "1", NewSpirit = 1, NewDurability = 1,
            NewStamina = 1, NewStrength = 1, NewFuelCount = 1, NewIntellect = 1, NewLevel = 1,
            NewMaterialType = "1", NewName = "1", NewRarity = "1", NewRelatedMaterials = "1",
            NewResistanceValue = 1, NewReward = 1, NewToolId = 1
            }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.AdminItemCommandRedirectId, id, slot));

            if (slot == "Weapon")
            {
                var item = this.context.Weapons.FirstOrDefault();
                item.Agility.ShouldBe(1);
                item.Spirit.ShouldBe(1);
                item.Stamina.ShouldBe(1);
                item.Strength.ShouldBe(1);
                item.Intellect.ShouldBe(1);
                item.Type.ShouldNotBeNull();
                item.Level.ShouldBe(1);
                item.ClassType.ShouldBe("1");
                item.AttackPower.ShouldBe(1);
                item.Id.ShouldNotBeNull();
                item.BuyPrice.ShouldBe(1);
                item.SellPrice.ShouldBe(1);
                item.Name.ShouldBe("1");
                item.Slot.ShouldBe("Weapon");
                item.ImagePath.ShouldNotBeNull();
                item.IsCraftable.ShouldNotBeNull();
            }
            else if (slot == "Trinket")
            {
                var item = this.context.Trinkets.FirstOrDefault();
                item.Agility.ShouldBe(1);
                item.Spirit.ShouldBe(1);
                item.Stamina.ShouldBe(1);
                item.Strength.ShouldBe(1);
                item.Intellect.ShouldBe(1);
                item.Type.ShouldNotBeNull();
                item.Level.ShouldBe(1);
                item.ClassType.ShouldBe("1");
                item.Id.ShouldNotBeNull();
                item.BuyPrice.ShouldBe(1);
                item.SellPrice.ShouldBe(1);
                item.Name.ShouldBe("1");
                item.Slot.ShouldBe("Trinket");
                item.ImagePath.ShouldNotBeNull();
                item.IsCraftable.ShouldNotBeNull();
            }
            else if (slot == "Tool")
            {
                var item = this.context.Tools.FirstOrDefault();
                item.ImagePath.ShouldNotBeNull();
                item.Name.ShouldBe("1");
                item.SellPrice.ShouldBe(1);
                item.BuyPrice.ShouldBe(1);
                item.Slot.ShouldBe("Tool");
                item.Durability.ShouldBe(1);
                item.IsCraftable.ShouldNotBeNull();
            }
            else if (slot == "Material")
            {
                var item = this.context.Materials.FirstOrDefault();
                item.ImagePath.ShouldNotBeNull();
                item.Name.ShouldBe("1");
                item.SellPrice.ShouldBe(1);
                item.BuyPrice.ShouldBe(1);
                item.Slot.ShouldBe("Material");
                item.ToolId.ShouldBe(1);
                item.Type.ShouldNotBeNull();
                item.IsCraftable.ShouldNotBeNull();
                item.FuelCount.ShouldBe(1);
                item.RelatedMaterials.ShouldBe("1");
                item.IsCraftable.ShouldNotBeNull();
                item.IsDisolveable.ShouldNotBeNull();
                item.IsRefineable.ShouldNotBeNull();
            }
            else if (slot == "Treasure")
            {
                var item = this.context.Treasures.FirstOrDefault();
                item.Name.ShouldBe("1");
                item.ImagePath.ShouldNotBeNull();
                item.Rarity.ShouldBe("1");
                item.Slot.ShouldBe("Treasure");
                item.Reward.ShouldBe(1);
            }
            else if (slot == "Treasure Key")
            {
                var item = this.context.TreasureKeys.FirstOrDefault();
                item.Name.ShouldBe("1");
                item.ImagePath.ShouldNotBeNull();
                item.Rarity.ShouldBe("1");
                item.Slot.ShouldBe("Treasure Key");
            }
            else
            {
                var item = this.context.Armors.FirstOrDefault();
                item.Agility.ShouldBe(1);
                item.Spirit.ShouldBe(1);
                item.Stamina.ShouldBe(1);
                item.Strength.ShouldBe(1);
                item.Intellect.ShouldBe(1);
                item.Type.ShouldNotBeNull();
                item.Level.ShouldBe(1);
                item.ClassType.ShouldBe("1");
                item.Id.ShouldNotBeNull();
                item.BuyPrice.ShouldBe(1);
                item.SellPrice.ShouldBe(1);
                item.Name.ShouldBe("1");
                item.Slot.ShouldBe("Armor");
                item.ArmorValue.ShouldBe(1);
                item.ResistanceValue.ShouldBe(1);
                item.ImagePath.ShouldNotBeNull();
                item.IsCraftable.ShouldNotBeNull();
            }
        }
    }
}
