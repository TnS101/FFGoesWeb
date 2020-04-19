namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFriendsQueryHandler : IRequestHandler<GetAllFriendsQuery, UserListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public GetAllFriendsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<UserListViewModel> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var friends = await this.context.Friends.Where(f => f.UserId == user.Id).ToListAsync();

            var users = new Queue<AppUser>();

            foreach (var appUser in this.context.AppUsers)
            {
                foreach (var friend in friends)
                {
                    if (appUser.Id == friend.Id)
                    {
                        users.Enqueue(appUser);
                    }
                }
            }

            return new UserListViewModel
            {
                Users = users.Select(u => new UserPartialViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    ForumPoints = u.ForumPoints,
                    MasteryPoints = u.MasteryPoints,
                }),
            };
        }
    }
}
