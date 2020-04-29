using Application.GameCQ.Monsters.Queries.GetAllMonstersQuery;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Monsters.Queries
{
    public class GetAllMonstersQueryHandlerTests : QueryTestFixture
    {
        private GetAllMonstersQueryHandler sut;

        public GetAllMonstersQueryHandlerTests()
        {
            QueryArrangeHelper.AddMonsters(context);
            this.sut = new GetAllMonstersQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldReturnAllMonsters()
        {
            var status = await this.sut.Handle(new GetAllMonstersQuery { }, CancellationToken.None);

            status.ShouldNotBeNull();
            status.ShouldBeOfType<MonsterListViewModel>();
            status.Monsters.Count().ShouldBe(9);
        }
    }
}
