namespace Application.CQ.Users.Queries.GetCurrentUser
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserPartialViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetCurrentUserQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UserPartialViewModel> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            AppUser user;
            if (request.User == null)
            {
                user = await this.context.AppUsers.FindAsync(request.UserId);
                var mappedUser = this.mapper.Map<UserPartialViewModel>(user);
                mappedUser.Friends = await this.context.Friends.Where(f => f.UserId == user.Id).ToListAsync();

                return mappedUser;
            }
            else
            {
                user = await this.userManager.GetUserAsync(request.User);
                var mappedUser = this.mapper.Map<UserPartialViewModel>(user);

                return mappedUser;
            }
        }
    }
}
