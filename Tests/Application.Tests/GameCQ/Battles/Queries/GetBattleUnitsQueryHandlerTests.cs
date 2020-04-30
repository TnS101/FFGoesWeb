using Application.GameCQ.Battles.Queries.GetBattleUnitsQuery;
using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
using Application.Tests.Infrastructure;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Battles.Queries
{
    public class GetBattleUnitsQueryHandlerTests : QueryTestFixture
    {
        private GetBattleUnitsQueryHandler sut;

        public GetBattleUnitsQueryHandlerTests()
        {
            this.sut = new GetBattleUnitsQueryHandler(mapper, context);
            CommandArrangeHelper.GetHeroId(context);
        }

        [Fact]
        public async Task ShouldGetBattleUnits()
        {
            var hero = new UnitFullViewModel { Id = "1" };

            var enemy = new Monster { Type = "Beast", Id = 9 };

            var result = new GetBattleUnitsQuery { Hero = hero, Enemy = enemy };

            result.ShouldNotBeNull();
            result.Hero.ShouldBeOfType<UnitFullViewModel>();
            result.Enemy.ShouldBeOfType<Monster>();
            result.Hero.ShouldNotBeNull();
            result.Hero.Id.ShouldBe("1");
            result.Enemy.Id.ShouldBe(9);
        }
    }
}
