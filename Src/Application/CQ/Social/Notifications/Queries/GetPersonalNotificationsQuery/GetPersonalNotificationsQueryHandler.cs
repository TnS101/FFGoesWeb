namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
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

    public class GetPersonalNotificationsQueryHandler : IRequestHandler<GetPersonalNotificationsQuery, NotificationListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public GetPersonalNotificationsQueryHandler(IFFDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<NotificationListViewModel> Handle(GetPersonalNotificationsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (request.Filter is null)
            {
                return new NotificationListViewModel
                {
                    Notifications = await this.context.Notifications.Where(n => n.UserId == user.Id).ProjectTo<NotificationFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else
            {
                return new NotificationListViewModel
                {
                    Notifications = await this.context.Notifications.Where(n => n.UserId == user.Id && n.Type == request.Filter).ProjectTo<NotificationFullViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
