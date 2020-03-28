﻿namespace Application.CQ.Social.FriendRequests.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

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

            var friend = await this.context.AppUsers.FindAsync(friendRequest.UserId);

            user.Friends.Add(friend);

            this.context.FriendRequests.Remove(friendRequest);

            this.context.AppUsers.Update(user);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
