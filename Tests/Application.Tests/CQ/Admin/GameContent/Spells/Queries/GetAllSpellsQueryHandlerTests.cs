namespace Application.Tests.CQ.Admin.GameContent.Spells.Queries
{
    using Application.CQ.Admin.GameContent.Spells.Queries.GetAllSpellsQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetAllSpellsQueryHandlerTests : QueryTestFixture
    {
        private readonly GetAllSpellsQueryHandler sut;

        public GetAllSpellsQueryHandlerTests()
        {
            this.sut = new GetAllSpellsQueryHandler(context, mapper);
            QueryArrangeHelper.AddSpells(context);
        }

        [Fact]
        public async Task ShouldGetAllSpells()
        {
            var status = await this.sut.Handle(new GetAllSpellsQuery { }, CancellationToken.None);

            status.ShouldBeOfType<SpellListViewModel>();
            status.Spells.Count().ShouldBe(4);
        }
    }
}
