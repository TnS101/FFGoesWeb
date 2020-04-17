namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFriendsQueryHandler : IRequestHandler<GetAllFriendsQuery, UserListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public GetAllFriendsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<UserListViewModel> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            return new UserListViewModel
            {
                Users = await this.context.AppUsers.Where(u => u.FriendId == user.Id).ProjectTo<UserPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
