using Application.GameCQ.Monsters.Commands.Create;
using Application.Tests.Infrastructure;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Monsters.Commands
{
    public class GenerateMonsterCommandHandlerTests : CommandTestBase
    {
        private readonly GenerateMonsterCommandHandler sut;

        public GenerateMonsterCommandHandlerTests()
        {
            this.sut = new GenerateMonsterCommandHandler(context);
            QueryArrangeHelper.AddMonsters(context);
        }

        [Fact]
        public async Task ShouldGenerateMonster()
        {
            var result = await this.sut.Handle(new GenerateMonsterCommand { PlayerLevel = 1, ZoneName = "World" }, CancellationToken.None);

            result.ShouldBeOfType<Monster>();
            result.ShouldNotBeNull();

            this.context.Monsters.Count().ShouldBe(9);
        }
    }
}
