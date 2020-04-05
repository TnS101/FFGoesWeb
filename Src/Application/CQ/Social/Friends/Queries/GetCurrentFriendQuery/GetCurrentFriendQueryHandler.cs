namespace Application.CQ.Social.Friends.Queries.GetCurrentFriendQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using MediatR;

    public class GetCurrentFriendQueryHandler : IRequestHandler<GetCurrentFriendQuery, UserViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetCurrentFriendQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetCurrentFriendQuery request, CancellationToken cancellationToken)
        {
            var friend = await this.context.AppUsers.FindAsync(request.FriendId);

            return this.mapper.Map<UserViewModel>(friend);
        }
    }
}
