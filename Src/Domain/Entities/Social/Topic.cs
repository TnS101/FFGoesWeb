namespace Domain.Entities.Social
{
    using Domain.Entities.Common;
    using Domain.Entities.Moderation;
    using System;
    using System.Collections.Generic;

    public class Topic
    {
        public Topic()
        {
            this.Comments = new HashSet<Comment>();
            this.Tickets = new HashSet<Ticket>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime? EditedOn { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
