using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Spells.Queries
{
    public class GetPersonalSpellsQueryHandlerTests : QueryTestFixture
    {
        private readonly GetPersonalSpellsQueryHandler sut;

        public GetPersonalSpellsQueryHandlerTests()
        {
            CommandArrangeHelper.GetFightingClassId(context);
            QueryArrangeHelper.AddSpells(context);
            this.sut = new GetPersonalSpellsQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldReturnSpellsByClass()
        {
            var classType = this.context.FightingClasses.FirstOrDefault().Type;

            var result = await this.sut.Handle(new GetPersonalSpellsQuery { ClassType = classType }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<SpellListViewModel>();
            result.Spells.Count().ShouldBe(4);
        }
    }
}
