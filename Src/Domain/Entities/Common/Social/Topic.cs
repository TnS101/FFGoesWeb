namespace Domain.Entities.Common.Social
{
    using System;
    using System.Collections.Generic;

    public class Topic
    {
        public Topic()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.UserTopics = new HashSet<UserTopics>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public DateTime CreateOn { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<UserTopics> UserTopics { get; set; }
    }
}
