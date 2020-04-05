namespace Application.CQ.Social.Notifications.Queries.GetPersonalNotificationsQuery
{
    using System;

    public class NotificationFullViewModel
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string ApplicationSection { get; set; }

        public string Content { get; set; }

        public string CauserName { get; set; }

        public DateTime RecievedOn { get; set; }
    }
}
