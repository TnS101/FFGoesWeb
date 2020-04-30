namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFriendsQueryHandler : UserHandler, IRequestHandler<GetAllFriendsQuery, UserListViewModel>
    {
        public GetAllFriendsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<UserListViewModel> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var friends = await this.Context.Friends.Where(f => f.UserId == user.Id).ToListAsync();

            var users = new Queue<AppUser>();

            foreach (var appUser in this.Context.AppUsers)
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
