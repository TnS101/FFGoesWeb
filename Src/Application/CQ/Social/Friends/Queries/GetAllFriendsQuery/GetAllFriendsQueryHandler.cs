namespace Application.CQ.Social.Friends.Queries.GetAllFriendsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllFriendsQueryHandler : BaseHandler, IRequestHandler<GetAllFriendsQuery, UserListViewModel>
    {
        public GetAllFriendsQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<UserListViewModel> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var friends = await this.Context.Friends.Where(f => f.UserId == request.UserId).AsNoTracking().Select(f => new UserPartialViewModel
            {
                Id = f.Id,
                UserName = f.User.UserName,
                ForumPoints = f.User.ForumPoints,
                MasteryPoints = f.User.MasteryPoints,
            }).ToArrayAsync();

            return new UserListViewModel { Users = friends };
        }
    }
}
