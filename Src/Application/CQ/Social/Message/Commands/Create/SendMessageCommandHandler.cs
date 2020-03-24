﻿namespace Application.CQ.Forum.Message.Commands.Create
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public SendMessageCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var reciever = this.context.AppUsers.FirstOrDefault(r => r.UserName == request.RecieverName);

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                request.Content = "[blank]";
            }

            reciever.Messages.Add(new Domain.Entities.Common.Social.Message
            {
                Content = request.Content,
                SenderName = sender.UserName,
                SentOn = DateTime.UtcNow,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CreateMessageCommandRedirect, reciever.UserName);
        }
    }
}