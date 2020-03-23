namespace Application.CQ.Forum.Message.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, string>
    {
        private readonly IFFDbContext context;
        public DeleteMessageCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToRemove = await this.context.Messages.FindAsync(request.MessageId);

            messageToRemove.Content = "[Message Deleted]";

            this.context.Messages.Update(messageToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.MessageCommandRedirect;
        }
    }
}
