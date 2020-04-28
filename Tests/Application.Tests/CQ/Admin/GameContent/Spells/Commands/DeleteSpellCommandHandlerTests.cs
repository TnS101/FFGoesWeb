namespace Application.Tests.CQ.Admin.GameContent.Spells.Commands
{
    using Application.CQ.Admin.GameContent.Spells.Commands.Delete;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteSpellCommandHandlerTests : CommandTestBase
    {
        private readonly int spellId;
        private readonly DeleteSpellCommandHandler sut;

        public DeleteSpellCommandHandlerTests()
        {
            this.spellId = CommandArrangeHelper.GetSpellId(context);
            this.sut = new DeleteSpellCommandHandler(context);
        }

        [Fact]
        public async Task ShouldDeleteSpell()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new DeleteSpellCommand { SpellId = this.spellId }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(GConst.AdminSpellCommandRedirect);
            this.context.Spells.Count().ShouldBe(0);
        }
    }
}
