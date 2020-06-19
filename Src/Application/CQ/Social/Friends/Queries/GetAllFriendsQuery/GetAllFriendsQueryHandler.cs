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

    public class GetAllFriendsQueryHandler : BaseHandler, IRequestHandler<GetAllFriendsQuery, UserListViewModel>
    {
        public GetAllFriendsQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<UserListViewModel> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var friends = this.Context.Friends.Where(f => f.UserId == user.Id);

            var result = new UserListViewModel { };

            foreach (var appUser in this.Context.AppUsers)
            {
                foreach (var friend in friends)
                {
                    if (appUser.Id == friend.Id)
                    {
                        result.Users.ToList().Add(new UserPartialViewModel
                        {
                            Id = appUser.Id,
                            UserName = appUser.UserName,
                            ForumPoints = appUser.ForumPoints,
                            MasteryPoints = appUser.MasteryPoints,
                        });
                    }
                }
            }

            return result;
        }
    }
}
