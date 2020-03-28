namespace Application.CQ.Social.FriendRequests.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public SendFriendRequestCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var reciever = await this.context.AppUsers.FindAsync(request.RecieverId);

            reciever.FriendRequests.Add(new Domain.Entities.Common.Social.FriendRequest
            {
                SenderName = sender.UserName,
                SentOn = DateTime.UtcNow,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
