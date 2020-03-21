namespace Application.CQ.Forum.FriendRequest.Commands.Create
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public SendFriendRequestCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var reciever = await this.context.Users.FindAsync(request.RecieverId);

            reciever.FriendRequests.Add(new Domain.Entities.Common.Social.FriendRequest
            {
                User = sender,
                SentOn = DateTime.UtcNow
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
