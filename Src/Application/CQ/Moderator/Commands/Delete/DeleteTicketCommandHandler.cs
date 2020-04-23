namespace Application.CQ.Moderator.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteTicketCommandHandler : BaseHandler, IRequestHandler<DeleteTicketCommand, string>
    {
        public DeleteTicketCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            this.Context.Tickets.Remove(this.Context.Tickets.Find(request.TicketId));

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.TicketCommandRedirect;
        }
    }
}
