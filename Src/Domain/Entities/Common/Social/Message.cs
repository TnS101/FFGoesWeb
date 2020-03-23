namespace Domain.Entities.Common.Social
{
    using Domain.Entities.Moderation;
    using System;
    using System.Collections.Generic;

    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tickets = new HashSet<Ticket>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public bool IsReportedByUser { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? EditedOn { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
