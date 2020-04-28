namespace Application.Tests.CQ.Admin.GameContent.Spells.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Admin.GameContent.Spells.Queries.GetCurrentSpellQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetCurrentSpellQueryHandlerTests : QueryTestFixture
    {
        private readonly int spellId;
        private readonly GetCurrentSpellQueryHandler sut;

        public GetCurrentSpellQueryHandlerTests()
        {
            this.spellId = CommandArrangeHelper.GetSpellId(context);
            this.sut = new GetCurrentSpellQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldGetCurrentSpell()
        {
            var status = await this.sut.Handle(new GetCurrentSpellQuery { SpellId = this.spellId }, CancellationToken.None);

            status.ShouldBeOfType<SpellFullViewModel>();
        }
    }
}
