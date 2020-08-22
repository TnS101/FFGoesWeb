namespace Application.CQ.Social.FriendRequests.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalFriendRequestsQueryHandler : MapperHandler, IRequestHandler<GetPersonalFriendRequestsQuery, FriendRequestListViewModel>
    {
        public GetPersonalFriendRequestsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<FriendRequestListViewModel> Handle(GetPersonalFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            return new FriendRequestListViewModel
            {
                FriendRequests = await this.Context.FriendRequests.Where(f => f.UserId == request.UserId).AsNoTracking().ProjectTo<FriendRequestFullViewModel>(this.Mapper.ConfigurationProvider)
                .ToArrayAsync(),
            };
        }
    }
}
