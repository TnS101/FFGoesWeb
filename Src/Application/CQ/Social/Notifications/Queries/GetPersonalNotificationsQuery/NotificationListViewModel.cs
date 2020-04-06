namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
{
    using System.Collections.Generic;

    public class NotificationListViewModel
    {
        public IEnumerable<NotificationFullViewModel> Notifications { get; set; }
    }
}
