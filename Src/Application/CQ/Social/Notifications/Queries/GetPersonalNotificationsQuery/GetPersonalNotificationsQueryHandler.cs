namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetPersonalNotificationsQueryHandler : FullHandler, IRequestHandler<GetPersonalNotificationsQuery, NotificationListViewModel>
    {
        public GetPersonalNotificationsQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
            : base(context, userManager, mapper)
        {
        }

        public async Task<NotificationListViewModel> Handle(GetPersonalNotificationsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            if (request.Filter is null)
            {
                return new NotificationListViewModel
                {
                    Notifications = await this.Context.Notifications.Where(n => n.UserId == user.Id).ProjectTo<NotificationFullViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else
            {
                return new NotificationListViewModel
                {
                    Notifications = await this.Context.Notifications.Where(n => n.UserId == user.Id && n.Type == request.Filter).ProjectTo<NotificationFullViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
