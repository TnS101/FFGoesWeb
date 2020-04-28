namespace Application.Tests.CQ.Admin.GameContent.FightingClasses.Commands
{
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Delete;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteFightingClassCommandHandlerTests : CommandTestBase
    {
        private readonly int fightingClassId;
        private readonly DeleteFightingClassCommandHandler sut;

        public DeleteFightingClassCommandHandlerTests()
        {
            this.sut = new DeleteFightingClassCommandHandler(context);
            this.fightingClassId = CommandArrangeHelper.GetFightingClassId(context);
        }

        [Fact]
        public async Task ShouldDeleteFightingClass()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new DeleteFightingClassCommand { FightingClassId = this.fightingClassId }, CancellationToken.None));

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(GConst.AdminFightingClassCommandRedirect, status.Result.ToString());
            Assert.Equal(0, this.context.FightingClasses.Count());
        }
    }
}
