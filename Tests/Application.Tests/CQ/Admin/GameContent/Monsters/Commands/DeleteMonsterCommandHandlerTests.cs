namespace Application.Tests.CQ.Admin.GameContent.Monsters.Commands
{
    using Application.CQ.Admin.GameContent.Monsters.Commands.Delete;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteMonsterCommandHandlerTests : CommandTestBase
    {
        private readonly int monsterId;
        private readonly DeleteMonsterCommandHandler sut;

        public DeleteMonsterCommandHandlerTests()
        {
            this.sut = new DeleteMonsterCommandHandler(context);
            this.monsterId = CommandArrangeHelper.GetMonsterId(context);
        }

        [Fact]
        public async Task ShoudlDeleteMonster()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new DeleteMonsterCommand { MonsterId = this.monsterId }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(GConst.AdminMonsterCommandRedirect);

            this.context.Monsters.Count().ShouldBe(0);
        }
    }
}
