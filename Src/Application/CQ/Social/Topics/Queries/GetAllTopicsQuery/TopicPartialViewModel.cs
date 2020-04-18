namespace Application.CQ.Social.Topics.Queries.GetAllTopicsQuery
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities.Social;

    public class TopicPartialViewModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public ICollection<Like> Likes { get; set; }

        public DateTime CreateOn { get; set; }

        public int Comments { get; set; }
    }
}
