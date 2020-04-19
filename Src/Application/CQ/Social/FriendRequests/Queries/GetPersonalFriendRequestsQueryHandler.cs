namespace Application.CQ.Social.FriendRequests.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalFriendRequestsQueryHandler : IRequestHandler<GetPersonalFriendRequestsQuery, FriendRequestListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public GetPersonalFriendRequestsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<FriendRequestListViewModel> Handle(GetPersonalFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var reciever = await this.userManager.GetUserAsync(request.Reciever);

            return new FriendRequestListViewModel
            {
                FriendRequests = await this.context.FriendRequests.Where(f => f.UserId == reciever.Id).ProjectTo<FriendRequestFullViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(),
            };
        }
    }
}
