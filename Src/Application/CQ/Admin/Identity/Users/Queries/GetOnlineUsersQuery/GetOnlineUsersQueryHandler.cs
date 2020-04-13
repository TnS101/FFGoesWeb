namespace Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetOnlineUsersQueryHandler : IRequestHandler<GetOnlineUsersQuery, UserListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetOnlineUsersQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserListViewModel> Handle(GetOnlineUsersQuery request, CancellationToken cancellationToken)
        {
            var cookies = new CookieCollection();

            var loginCookie = cookies["userLogin"];
            var users = await this.context.AppUsers.Where(au => au.IsOnline).ProjectTo<UserPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync();

            if (users.Count() > 0)
            {
                foreach (var user in users)
                {
                    user.OnlineTime = DateTime.UtcNow.Minute - DateTime.ParseExact(loginCookie.Value, "MM/dd/yyyy H:mm", CultureInfo.InvariantCulture).Minute;
                }
            }

            return new UserListViewModel
            {
                Users = users,
            };
        }
    }
}
