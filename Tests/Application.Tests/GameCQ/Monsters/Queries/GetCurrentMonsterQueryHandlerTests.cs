using Application.GameCQ.Monsters.Queries.GetCurrentMonsterQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Monsters.Queries
{
    public class GetCurrentMonsterQueryHandlerTests : QueryTestFixture
    {
        private readonly int monsterId;
        private readonly GetCurrentMonsterQueryHandler sut;

        public GetCurrentMonsterQueryHandlerTests()
        {
            this.monsterId = CommandArrangeHelper.GetMonsterId(context);
            this.sut = new GetCurrentMonsterQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShoudlGetCurrentMonster()
        {
            var result = await this.sut.Handle(new GetCurrentMonsterQuery { MonsterId = this.monsterId }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<MonsterFullViewModel>();
        }
    }
}
