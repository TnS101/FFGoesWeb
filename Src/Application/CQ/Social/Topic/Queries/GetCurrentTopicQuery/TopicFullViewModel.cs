namespace Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;

    public class TopicFullViewModel
    {
        public TopicFullViewModel()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public DateTime CreateOn { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
