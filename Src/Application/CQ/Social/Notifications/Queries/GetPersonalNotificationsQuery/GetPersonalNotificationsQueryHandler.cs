namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
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

    public class GetPersonalNotificationsQueryHandler : MapperHandler, IRequestHandler<GetPersonalNotificationsQuery, NotificationListViewModel>
    {
        public GetPersonalNotificationsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<NotificationListViewModel> Handle(GetPersonalNotificationsQuery request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

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
