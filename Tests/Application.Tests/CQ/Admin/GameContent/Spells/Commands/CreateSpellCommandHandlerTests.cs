namespace Application.Tests.CQ.Admin.GameContent.Spells.Commands
{
    using Application.CQ.Admin.GameContent.Spells.Commands.Create;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateSpellCommandHandlerTests : CommandTestBase
    {
        private CreateSpellCommandHandler sut;

        public CreateSpellCommandHandlerTests()
        {
            this.sut = new CreateSpellCommandHandler(context);
        }

        [Fact]
        public async Task ShouldCreateSpell()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new CreateSpellCommand { }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(GConst.AdminSpellCommandRedirect);
            this.context.Spells.Count().ShouldBe(1);
        }
    }
}
