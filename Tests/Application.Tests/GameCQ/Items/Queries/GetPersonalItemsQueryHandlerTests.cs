namespace Application.Tests.GameCQ.Items.Queries
{
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetPersonalItemsQueryHandlerTests : QueryTestFixture
    {
        private readonly string heroId;
        private GetPersonalItemsQueryHandler sut;

        public GetPersonalItemsQueryHandlerTests()
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

            this.sut = new GetPersonalItemsQueryHandler(context);
            this.heroId = CommandArrangeHelper.GetHeroId(context);
        }

        [Fact]
        public async Task ShouldCurrentFightingClass()
        {
            await this.Result("Weapon");
            await this.Result("Armor");
            await this.Result("Trinket");
            await this.Result("Tool");
            await this.Result("Material");
            await this.Result("Treasure");
            await this.Result("Treasure Key");
        }

        private async Task Result(string slot)
        {
            var result = await this.sut.Handle(new GetPersonalItemsQuery { HeroId = this.heroId, Slot = slot }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ItemListViewModel>();

            if (slot == "Weapon")
            {
                result.Items.Count().ShouldBe(1);
            }

            if (slot == "Trinket")
            {
                result.Items.Count().ShouldBe(1);
            }

            if (slot == "Armor")
            {
                result.Items.Count().ShouldBe(1);
            }

            if (slot == "Tool")
            {
                result.Items.Count().ShouldBe(1);
            }

            if (slot == "Material")
            {
                result.Items.Count().ShouldBe(1);
            }

            if (slot == "Treasure")
            {
                result.Items.Count().ShouldBe(1);
            }

            if (slot == "Treasure Key")
            {
                result.Items.Count().ShouldBe(1);
            }
        }
    }
}
