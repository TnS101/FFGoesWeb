namespace Application.Tests.CQ.Admin.GameContent.Items.Queries
{
    using System.Collections.Generic;
    using Xunit;
    using Shouldly;
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllItemsQuery;
    using System.Threading.Tasks;
    using Application.Tests.Infrastructure;
    using System.Threading;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using System.Linq;

    public class GetAllItemsQueryHandlerTests : QueryTestFixture
    {
        private GetAllItemsQueryHandler sut;

        public GetAllItemsQueryHandlerTests()
        {
            QueryArrangeHelper.AddArmors(context);
            this.sut = new GetAllItemsQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldReturnAllItems()
        {
            var result = await this.sut.Handle(new GetAllItemsQuery { }, CancellationToken.None);

            result.Items.ShouldBeOfType<List<ItemMinViewModel>>();
            result.Items.Count().ShouldBe(7);
        }
    }
}
