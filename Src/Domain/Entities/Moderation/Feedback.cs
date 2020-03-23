namespace Domain.Entities.Moderation
{
    using Domain.Entities.Common;
    using System;

    public class Feedback
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string Content { get; set; }

        public int Stars { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime SentOn { get; set; }
    }
}
