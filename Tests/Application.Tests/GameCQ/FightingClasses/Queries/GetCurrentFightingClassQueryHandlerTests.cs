using Application.GameCQ.FightingClasses.Queries.GetCurrentFightingClassQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
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

            result.ShouldBeOfType<FightingClassFullViewModel>();
        }
    }
}
