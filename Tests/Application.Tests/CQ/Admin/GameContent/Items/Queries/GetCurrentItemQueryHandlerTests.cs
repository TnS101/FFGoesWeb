namespace Application.Tests.CQ.Admin.GameContent.Items.Queries
{
    using Application.CQ.Admin.GameContent.Items.Queries.GetCurrentItemQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetCurrentItemQueryHandlerTests : QueryTestFixture
    {
        private GetCurrentItemQueryHandler sut;

        public GetCurrentItemQueryHandlerTests()
        {
            QueryArrangeHelper.AddMaterials(context);
            this.sut = new GetCurrentItemQueryHandler(context);
        }

        [Fact]
        public async Task ShouldReturnCurrentItemById()
        {
            var status = await this.sut.Handle(new GetCurrentItemQuery { ItemId = "1", Slot = "Material" }, CancellationToken.None);

            status.Id.ShouldBe("1");
            status.ShouldBeOfType<ItemFullViewModel>();
        }
    }
}
