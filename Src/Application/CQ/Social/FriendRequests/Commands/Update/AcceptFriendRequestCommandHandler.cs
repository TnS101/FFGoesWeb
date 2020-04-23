namespace Application.CQ.Social.FriendRequests.Commands.Update
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
    using Microsoft.EntityFrameworkCore;

    public class AcceptFriendRequestCommandHandler : UserHandler, IRequestHandler<AcceptFriendRequestCommand, string>
    {
        public AcceptFriendRequestCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.Reciever);

            var friendRequest = await this.Context.FriendRequests.FindAsync(request.RequestId);

            var senderName = friendRequest.SenderName;

            var friend = await this.Context.AppUsers.FirstOrDefaultAsync(f => f.UserName == senderName);

            this.AddFriends(user, friend);

            this.SendNotification(user, friend);

            this.Context.FriendRequests.Remove(friendRequest);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }

        private void AddFriends(AppUser user, AppUser friend)
        {
            this.Context.Friends.Add(new Friend
            {
                Id = user.Id,
                UserId = friend.Id,
            });

            this.Context.Friends.Add(new Friend
            {
                Id = friend.Id,
                UserId = user.Id,
            });
        }

        private void SendNotification(AppUser user, AppUser friend)
        {
            this.Context.Notifications.Add(new Notification
            {
                UserId = friend.Id,
                ApplicationSection = "Social",
                Type = "Friend",
                Content = string.Format(GConst.FriendRequestAcceptMessage, user.UserName),
                RecievedOn = DateTime.UtcNow,
            });
        }
    }
}
