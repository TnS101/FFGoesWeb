namespace Application.Tests.CQ.Moderator.Commands
{
    using Application.CQ.Moderator.Commands.Delete;
    using Application.Tests.Infrastructure;
    using global::Common;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class DeleteTicketCommandHandlerTests : CommandTestBase
    {
        private readonly int ticketId;
        private readonly DeleteTicketCommandHandler sut;

        public DeleteTicketCommandHandlerTests()
        {
            this.sut = new DeleteTicketCommandHandler(context);
            this.ticketId = CommandArrangeHelper.GetTicketId(context);
        }

        [Fact]
        public async Task ShoudlDeleteTicket()
        {
            var status = Task<string>.FromResult(await this.sut.Handle(new DeleteTicketCommand { TicketId = this.ticketId }, CancellationToken.None));

            status.Status.ToString().ShouldBe(GConst.SuccessStatus);
            status.Result.ToString().ShouldBe(GConst.TicketCommandRedirect);
            this.context.Tickets.Count().ShouldBe(0);
        }
    }
}
