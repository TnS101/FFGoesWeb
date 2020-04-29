namespace Application.Tests.CQ.Admin.GameContent.Items.Commands
{
    using Application.CQ.Admin.GameContent.Items.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateItemCommandHandlerTests : CommandTestBase
    {
        private readonly CreateItemCommandHandler sut;

        public CreateItemCommandHandlerTests()
        {
            this.sut = new CreateItemCommandHandler(context);
        }

        [Fact]
        public async Task ShouldCreateItem()
        {
            await this.Status("Material");
            await this.Status("Tool");
            await this.Status("Treasure Key");
            await this.Status("Treasure");
            await this.Status("Weapon");
            await this.Status("Armor");
            await this.Status("Trinket");
        }

        private async Task Status(string slot)
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new CreateItemCommand {
                Slot = slot,
                Agility = 1,
                MaterialDiversity = "1",
                ArmorValue = 1,
                AttackPower = 1,
                SellPrice = 1,
                BuyPrice = 1,
                ClassType = "1",
                Spirit = 1,
                Durability = 1,
                Stamina = 1,
                Strength = 1,
                FuelCount = 1,
                Intellect = 1,
                Level = 1,
                MaterialType = "1",
                Name = "1",
                Rarity = "1",
                RelatedMaterials = "1",
                ResistanceValue = 1,
                Reward = 1,
                ToolId = 1,
            }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);

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

                context.Weapons.Count().ShouldBe(1);
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

                context.Trinkets.Count().ShouldBe(1);
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

                context.Tools.Count().ShouldBe(1);
            }
            else if (slot == "Material")
            {
                var item = this.context.Materials.FirstOrDefault();
                item.ImagePath.ShouldNotBeNull();
                item.Name.ShouldBe("1");
                item.SellPrice.ShouldBe(1);
                item.BuyPrice.ShouldBe(1);
                item.Slot.ShouldBe("Material");
                item.Type.ShouldNotBeNull();
                item.IsCraftable.ShouldNotBeNull();
                if (item.IsCraftable || item.IsDisolveable || item.IsRefineable)
                {
                    item.ToolId.ShouldBe(1);
                }
                else
                {
                    item.ToolId.ShouldBeNull();
                }

                item.FuelCount.ShouldBe(1);
                item.RelatedMaterials.ShouldBe("1");
                item.IsCraftable.ShouldNotBeNull();
                item.IsDisolveable.ShouldNotBeNull();
                item.IsRefineable.ShouldNotBeNull();

                context.Materials.Count().ShouldBe(1);
            }
            else if (slot == "Treasure")
            {
                var item = this.context.Treasures.FirstOrDefault();
                item.Name.ShouldBe("1");
                item.ImagePath.ShouldNotBeNull();
                item.Rarity.ShouldBe("1");
                item.Slot.ShouldBe("Treasure");
                item.Reward.ShouldBe(1);

                context.Treasures.Count().ShouldBe(1);
            }
            else if (slot == "Treasure Key")
            {
                var item = this.context.TreasureKeys.FirstOrDefault();
                item.Name.ShouldBe("1");
                item.ImagePath.ShouldNotBeNull();
                item.Rarity.ShouldBe("1");
                item.Slot.ShouldBe("Treasure Key");

                context.TreasureKeys.Count().ShouldBe(1);
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

                context.Armors.Count().ShouldBe(1);
            }
        }
    }
}
