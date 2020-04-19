﻿namespace Application.CQ.Social.FriendRequests.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class AcceptFriendRequestCommandHandler : IRequestHandler<AcceptFriendRequestCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public AcceptFriendRequestCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.Reciever);

            var friendRequest = await this.context.FriendRequests.FindAsync(request.RequestId);

            var senderName = friendRequest.SenderName;

            var friend = await this.context.AppUsers.FirstOrDefaultAsync(f => f.UserName == senderName);

            await this.AddFriends(user, friend);

            await this.SendNotification(user, friend);

            this.context.FriendRequests.Remove(friendRequest);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }

        private async Task AddFriends(AppUser user, AppUser friend)
        {
            await this.context.Friends.AddAsync(new Friend
            {
                Id = user.Id,
                UserId = friend.Id,
            });

            await this.context.Friends.AddAsync(new Friend
            {
                Id = friend.Id,
                UserId = user.Id,
            });
        }

        private async Task SendNotification(AppUser user, AppUser friend)
        {
            await this.context.Notifications.AddAsync(new Notification
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
