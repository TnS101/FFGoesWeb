using Application.GameCQ.FightingClasses.Queries.GetAllFightingClassesQuery;
using Application.GameCQ.Heroes.Commands.Create;
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
    public class GetAllFightingClassesQueryHandlerTests : QueryTestFixture
    {
        private GetAllFightingClassesQueryHandler sut;

        public GetAllFightingClassesQueryHandlerTests()
        {
            this.sut = new GetAllFightingClassesQueryHandler(context, mapper);
            QueryArrangeHelper.AddFightingClasses(context);
        }

        [Fact]
        public async Task ShouldReturnAllFightingClasses()
        {
            var result = await this.sut.Handle(new GetAllFightingClassesQuery { }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.FightingClasses.ShouldBeOfType<List<FightingClassMinViewModel>>();
            result.FightingClasses.Count().ShouldBe(9);

            int counter = 1;

            foreach (var fightingClass in result.FightingClasses)
            {
                fightingClass.Id.ShouldBe(counter);
                fightingClass.Description.ShouldBe("sdawd");
                fightingClass.ImagePath.ShouldBe("adawda");
                fightingClass.IconPath.ShouldBe("awdawdwad");
                counter++;
            }
        }
    }
}
