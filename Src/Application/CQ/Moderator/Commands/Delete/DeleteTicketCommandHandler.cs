namespace Application.CQ.Moderator.Commands.Delete
{
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteTicketCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            this.context.Tickets.Remove(this.context.Tickets.Find(request.TicketId));

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TicketCommandRedirect;
        }
    }
}
