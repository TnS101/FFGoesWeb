namespace Domain.Entities.Common.Social
{
    using System;

    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? EditedOn { get; set; }
    }
}
