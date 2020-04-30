namespace Application.CQ.Users.Queries.GetCurrentUser
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.CQ.Social.Friends.Queries.GetAllFriendsQuery;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetCurrentUserQueryHandler : MapperHandler, IRequestHandler<GetCurrentUserQuery, UserPartialViewModel>
    {
        public GetCurrentUserQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
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
