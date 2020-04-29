using Application.GameCQ.Heroes.Commands.Delete;
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

namespace Application.Tests.GameCQ.Heroes.Commands
{
    public class DeleteHeroCommandHandlerTests : CommandTestBase
    {
        private readonly string heroId;
        private readonly DeleteHeroCommandHandler sut;

        public DeleteHeroCommandHandlerTests()
        {
            this.sut = new DeleteHeroCommandHandler(context);
            this.heroId = CommandArrangeHelper.GetHeroId(context);
            CommandArrangeHelper.GetInventoryId(context);
            CommandArrangeHelper.GetEquipementId(context);
            QueryArrangeHelper.AddEnergyChanges(context);
        }

        [Fact]
        public async Task ShouldDeleteHeroWithAllOfHisRelations()
        {
            var result = await this.sut.Handle(new DeleteHeroCommand { HeroId = this.heroId }, CancellationToken.None);

            result.ShouldBe(GConst.HeroCommandRedirect);
            this.context.Heroes.Count().ShouldBe(0);
            this.context.Inventories.Count().ShouldBe(0);
            this.context.Equipments.Count().ShouldBe(0);
            this.context.EnergyChanges.Count().ShouldBe(0);
        }
    }
}
