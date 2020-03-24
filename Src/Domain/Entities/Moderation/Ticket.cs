namespace Domain.Entities.Moderation
{
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using System;

    public class Ticket
    {
        public Ticket()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string TopicId { get; set; }

        public Topic Topic { get; set; }

        public string CommentId { get; set; }

        public Comment Comment { get; set; }

        public string MessageId { get; set; }

        public Message Message { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }

        public string ReportedUserName { get; set; }

        public string AdditionalInformation { get; set; }

        public int Stars { get; set; }

        public DateTime SentOn { get; set; }
    }
}
