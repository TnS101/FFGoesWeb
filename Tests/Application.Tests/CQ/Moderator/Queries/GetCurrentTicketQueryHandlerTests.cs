namespace Application.Tests.CQ.Moderator.Queries
{
    using Application.CQ.Moderator.Queries.GetCurrentTicketQuery;
    using Application.Tests.Infrastructure;
    using Shouldly;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetCurrentTicketQueryHandlerTests : QueryTestFixture
    {
        private readonly GetCurrentTicketQueryHandler sut;

        public GetCurrentTicketQueryHandlerTests()
        {
            this.sut = new GetCurrentTicketQueryHandler(context, mapper);
            QueryArrangeHelper.AddUsers(context);
            QueryArrangeHelper.AddTopics(context);
            QueryArrangeHelper.AddTickets(context);
            QueryArrangeHelper.AddComments(context);
            QueryArrangeHelper.AddMessages(context);
        }

        [Fact]
        public async Task ShoudlGetCurrentTicket()
        {
            foreach (var ticket in context.Tickets)
            {
                var status = await this.sut.Handle(new GetCurrentTicketQuery { TicketId = ticket.Id }, CancellationToken.None);
                status.Id.ShouldNotBeNull();
                status.Content.ShouldNotBeNull();
                status.Content.ShouldBe("sewew");
                status.Type.ShouldNotBeNull();
                status.Category.ShouldNotBeNull();
                status.AdditionalInformation.ShouldNotBeNull();
                status.SentOn.ShouldNotBeNull();
                status.ShouldBeOfType<TicketFullViewModel>();
            }
        }
    }
}
