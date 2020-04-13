namespace Application.CQ.Users.Queries.GetCurrentUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

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
            AppUser user = null;

            if (request.User == null)
            {
                user = await this.context.AppUsers.FindAsync(request.UserId);
            }
            else
            {
                user = await this.userManager.GetUserAsync(request.User);
            }

            return this.mapper.Map<UserPartialViewModel>(user);
        }
    }
}
