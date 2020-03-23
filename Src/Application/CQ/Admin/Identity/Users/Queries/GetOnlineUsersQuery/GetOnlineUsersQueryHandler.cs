namespace Application.CQ.Admin.Users.Queries
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

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
            var users = new UserListViewModel { };

            if (!this.context.Users.Any(u => u.IsLoggedIn))
            {
                return new UserListViewModel
                {
                    Users = await this.context.Users.ProjectTo<UserPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync()
                };
            }

            if (request.Role is null)
            {
                //users = new UserListViewModel { Users = await this.context.Users.ProjectTo<UserPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync() };
            }
            else
            {
                //users = new UserListViewModel { Users = await this.context.Users.Where(u => (request.Role)).ProjectTo<UserPartialViewModel>(this.mapper.ConfigurationProvider).ToListAsync() };
            }

            foreach (var user in users.Users)
            {
                user.OnlineTime = DateTime.UtcNow.Minute - DateTime.ParseExact(loginCookie.Value, "MM/dd/yyyy H:mm", CultureInfo.InvariantCulture).Minute;
            }

            return users;
        }
    }
}
