using Application.GameCQ.FightingClasses.Queries.GetCurrentFightingClassQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.FightingClasses.Queries
{
    public class GetCurrentFightingClassQueryHandlerTests : QueryTestFixture
    {
        private readonly int fightingClassId;
        private GetCurrentFightingClassQueryHandler sut;

        public GetCurrentFightingClassQueryHandlerTests()
        {
            this.sut = new GetCurrentFightingClassQueryHandler(context, mapper);
            this.fightingClassId = CommandArrangeHelper.GetFightingClassId(context);
        }

        [Fact]
        public async Task ShouldCurrentFightingClass()
        {
            var result = await this.sut.Handle(new GetCurrentFightingClassQuery { FightingClassId = this.fightingClassId }, CancellationToken.None);

            result.Id.ShouldBe(1);
            result.Description.ShouldBe("description");
            result.ArmorValue.ShouldBe(1);
            result.ResistanceValue.ShouldBe(1);
            result.AttackPower.ShouldBe(1);
            result.CritChance.ShouldBe(1);
            result.HealthRegen.ShouldBe(1);
            result.MagicPower.ShouldBe(1);
            result.MaxHP.ShouldBe(1000);
            result.ManaRegen.ShouldBe(1);
            result.MaxMana.ShouldBe(10);
            result.Type.ShouldBe("Warrior");

            result.ShouldBeOfType<FightingClassFullViewModel>();
        }
    }
}
