namespace Application.CQ.Admin.Users.Queries.GetOnlineUsersQuery
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetOnlineUsersQueryHandler : MapperHandler, IRequestHandler<GetOnlineUsersQuery, UserListViewModel>
    {
        public GetOnlineUsersQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<UserListViewModel> Handle(GetOnlineUsersQuery request, CancellationToken cancellationToken)
        {
            var cookies = new CookieCollection();

            var loginCookie = cookies["userLogin"];
            var users = await this.Context.AppUsers.Where(au => au.IsOnline).ProjectTo<UserPartialViewModel>(this.Mapper.ConfigurationProvider).ToListAsync();

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
