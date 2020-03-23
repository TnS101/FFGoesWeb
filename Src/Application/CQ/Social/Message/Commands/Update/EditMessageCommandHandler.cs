namespace Application.CQ.Forum.Message.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class EditMessageCommandHandler : IRequestHandler<EditMessageCommand, string>
    {
        private readonly IFFDbContext context;

        public EditMessageCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await this.context.Messages.FindAsync(request.MessageId);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = message.Content;
            }

            message.Content = request.Content;

            message.EditedOn = DateTime.UtcNow;

            this.context.Messages.Update(message);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.MessageCommandRedirect;
        }
    }
}
