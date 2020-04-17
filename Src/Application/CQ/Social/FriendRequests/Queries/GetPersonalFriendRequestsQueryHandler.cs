﻿namespace Application.CQ.Social.FriendRequest.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalFriendRequestsQueryHandler : IRequestHandler<GetPersonalFriendRequestsQuery, FriendRequestListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetPersonalFriendRequestsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<FriendRequestListViewModel> Handle(GetPersonalFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var reciever = await this.userManager.GetUserAsync(request.Reciever);

            var friendRequest = await this.context.FriendRequests.FindAsync(request.RequestId);

            if (friendRequest == null)
            {
                return null;
            }

            return new FriendRequestListViewModel
            {
                FriendRequests = await this.context.FriendRequests.Where(fr => fr.UserId == reciever.Id).Select(fr => new FriendRequestFullViewModel
                {
                    SenderName = friendRequest.SenderName,
                    SentOn = friendRequest.SentOn,
                })
                .OrderByDescending(s => s.SentOn)
                .ToListAsync(),
            };
        }
    }
}
