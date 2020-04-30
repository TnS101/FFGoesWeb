namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalNotificationsQuery : IRequest<NotificationListViewModel>
    {
        public string UserId { get; set; }

        public string Filter { get; set; }
    }
}
