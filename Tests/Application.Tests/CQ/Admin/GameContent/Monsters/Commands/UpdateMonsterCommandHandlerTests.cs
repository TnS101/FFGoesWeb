namespace Application.Tests.CQ.Admin.GameContent.Monsters.Commands
{
    using Application.CQ.Admin.GameContent.Monsters.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateMonsterCommandHandlerTests : CommandTestBase
    {
        private readonly int monsterId;
        private readonly UpdateMonsterCommandHandler sut;

        public UpdateMonsterCommandHandlerTests()
        {
            this.sut = new UpdateMonsterCommandHandler(context);
            this.monsterId = CommandArrangeHelper.GetMonsterId(context);
        }

        [Fact]
        public async Task ShouldUpdateMonster()
        {
            var result = await this.sut.Handle(new UpdateMonsterCommand { MonsterId = this.monsterId }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.AdminMonsterCommandRedirectId, this.monsterId));
        }
    }
}
