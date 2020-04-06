namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalNotificationsQuery : IRequest<NotificationListViewModel>
    {
        public ClaimsPrincipal User { get; set; }

        public string Filter { get; set; }
    }
}
