namespace Application.CQ.Social.FriendRequests.Queries
{
    using System;

    public class FriendRequestFullViewModel
    {
        public int Id { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }
    }
}
