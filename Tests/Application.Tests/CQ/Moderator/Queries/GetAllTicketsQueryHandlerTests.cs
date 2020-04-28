namespace Application.Tests.CQ.Moderator.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Moderator.Queries.GetAllTicketsQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using Xunit;

    public class GetAllTicketsQueryHandlerTests : QueryTestFixture
    {
        private readonly GetAllTicketsQueryHandler sut;

        public GetAllTicketsQueryHandlerTests()
        {
            this.sut = new GetAllTicketsQueryHandler(context, mapper);
            QueryArrangeHelper.AddTickets(context);
        }

        [Fact]
        public async Task ShouldGetAllTickets()
        {
            var status = await this.sut.Handle(new GetAllTicketsQuery { }, CancellationToken.None);

            status.ShouldBeOfType<TicketsListViewModel>();
            status.Tickets.Count().ShouldBe(3);
        }
    }
}
