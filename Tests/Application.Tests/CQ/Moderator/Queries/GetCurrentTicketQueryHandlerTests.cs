namespace Application.Tests.CQ.Moderator.Queries
{
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetCurrentTicketQueryHandlerTests : QueryTestFixture
    {
        private readonly int ticketId;
        private readonly GetCurrentTicketQueryHandler sut;

        public GetCurrentTicketQueryHandlerTests()
        {
            this.sut = new GetCurrentTicketQueryHandler(context, mapper);
            this.ticketId = CommandArrangeHelper.GetTicketId(context);
        }

        [Fact]
        public async Task ShoudlGetCurrentTicket()
        {
            var status = await this.sut.Handle(new GetCurrentTicketQuery { TicketId = this.ticketId }, CancellationToken.None);
            status.ShouldBeOfType<TicketFullViewModel>();
        }
    }
}
