namespace Application.CQ.Users.Queries.GetCurrentUser
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.CQ.Social.Friends.Queries.GetAllFriendsQuery;
    using AutoMapper;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentUserQueryHandler : FullHandler, IRequestHandler<GetCurrentUserQuery, UserPartialViewModel>
    {
        public GetCurrentUserQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
            : base(context, userManager, mapper)
        {
        }

        public async Task<UserPartialViewModel> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);
            var mappedUser = this.Mapper.Map<UserPartialViewModel>(user);
            mappedUser.Friends = await this.Context.Friends.Where(f => f.UserId == user.Id).ToListAsync();

            return mappedUser;
        }
    }
}
