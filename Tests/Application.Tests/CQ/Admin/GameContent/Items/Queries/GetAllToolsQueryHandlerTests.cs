﻿namespace Application.Tests.CQ.Admin.GameContent.Items.Queries
{
    using Application.CQ.Admin.GameContent.Items.Queries.GetAllToolsQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetAllToolsQueryHandlerTests : QueryTestFixture
    {
        private GetAllToolsQueryHandler sut;

        public GetAllToolsQueryHandlerTests()
        {
            QueryArrangeHelper.AddTools(context);
            this.sut = new GetAllToolsQueryHandler(context, mapper);
        }

        [Fact]
        public async Task ShouldReturnAllItems()
        {
            var status = await sut.Handle(new GetAllToolsQuery { }, CancellationToken.None);

            status.ShouldBeOfType<ToolsListViewModel>();

            int counter = 1;

            foreach (var tool in status.Tools)
            {
                tool.Id.ShouldBe(counter);
                tool.Name.ShouldBe("1");
                counter++;
            }

            status.Tools.Count().ShouldBe(3);
        }
    }
}
