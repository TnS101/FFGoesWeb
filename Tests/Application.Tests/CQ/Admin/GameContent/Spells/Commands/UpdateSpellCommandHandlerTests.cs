namespace Application.Tests.CQ.Admin.GameContent.Spells.Commands
{
    using Application.CQ.Admin.GameContent.Spells.Commands.Update;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class UpdateSpellCommandHandlerTests : CommandTestBase
    {
        private readonly int spellId;
        private readonly UpdateSpellCommandHandler sut;

        public UpdateSpellCommandHandlerTests()
        {
            this.sut = new UpdateSpellCommandHandler(context);
            this.spellId = CommandArrangeHelper.GetSpellId(context);
        }

        [Fact]
        public async Task ShouldUpdateSpell()
        {
            var result = await this.sut.Handle(new UpdateSpellCommand { SpellId = this.spellId }, CancellationToken.None);

            result.ShouldBe(GConst.AdminSpellCommandRedirect);
        }
    }
}
