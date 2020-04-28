namespace Application.Tests.CQ.Admin.GameContent.FightingClasses.Commands
{
    using Application.CQ.Admin.GameContent.FightingClasses.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateFightingClassCommandHandlerTests : CommandTestBase
    {
        private readonly int fightingClassId;
        private readonly UpdateFightingClassCommandHandler sut;

        public UpdateFightingClassCommandHandlerTests()
        {
            this.fightingClassId = CommandArrangeHelper.GetFightingClassId(context);
            this.sut = new UpdateFightingClassCommandHandler(context);
        }

        [Fact]
        public async Task ShouldUpdateFightingClass()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new UpdateFightingClassCommand { FightingClassId = this.fightingClassId }, CancellationToken.None));

            Assert.Equal(GConst.SuccessStatus, status.Status.ToString());
            Assert.Equal(string.Format(GConst.AdminFightingClassCommandRedirectId, 1), status.Result.ToString());
            Assert.Equal(1, this.context.FightingClasses.Count());
        }
    }
}
