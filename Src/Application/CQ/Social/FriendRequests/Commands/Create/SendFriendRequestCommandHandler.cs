namespace Application.CQ.Social.FriendRequests.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SendFriendRequestCommandHandler : UserHandler, IRequestHandler<SendFriendRequestCommand, string>
    {
        public SendFriendRequestCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.Context.AppUsers.FindAsync(request.UserId);

            var reciever = await this.Context.AppUsers.FindAsync(request.RecieverId);

            reciever.FriendRequests.Add(new FriendRequest
            {
                SenderName = sender.UserName,
                SentOn = DateTime.UtcNow,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
