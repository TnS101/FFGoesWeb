namespace Application.CQ.Social.Messages.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class EditMessageCommandHandler : BaseHandler, IRequestHandler<EditMessageCommand, string>
    {
        public EditMessageCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await this.Context.Messages.FindAsync(request.MessageId);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = message.Content;
            }

            message.Content = request.Content;

            message.EditedOn = DateTime.UtcNow;

            this.Context.Messages.Update(message);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.MessageCommandRedirect;
        }
    }
}
