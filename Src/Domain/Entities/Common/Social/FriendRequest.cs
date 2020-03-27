namespace Domain.Entities.Common.Social
{
    using System;

    public class FriendRequest
    {
        public FriendRequest()
        {
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }
    }
}
