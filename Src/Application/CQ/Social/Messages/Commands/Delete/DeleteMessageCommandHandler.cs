namespace Application.CQ.Social.Messages.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteMessageCommandHandler : BaseHandler, IRequestHandler<DeleteMessageCommand, string>
    {
        public DeleteMessageCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var messageToRemove = await this.Context.Messages.FindAsync(request.MessageId);

            messageToRemove.Content = "[Message Deleted]";

            this.Context.Messages.Update(messageToRemove);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.MessageCommandRedirect;
        }
    }
}
