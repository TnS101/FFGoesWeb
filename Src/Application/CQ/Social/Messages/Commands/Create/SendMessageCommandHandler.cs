﻿namespace Application.CQ.Social.Messages.Commands.Create
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;

    public class SendMessageCommandHandler : BaseHandler, IRequestHandler<SendMessageCommand, string>
    {
        public SendMessageCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.Context.AppUsers.FindAsync(request.UserId);

            var reciever = this.Context.AppUsers.FirstOrDefault(r => r.UserName == request.RecieverName);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = "[blank]";
            }

            reciever.Messages.Add(new Message
            {
                Content = request.Content,
                SenderName = sender.UserName,
                SentOn = DateTime.UtcNow,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CreateMessageCommandRedirect, reciever.UserName);
        }
    }
}
