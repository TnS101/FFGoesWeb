﻿namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities.Common;
    using Domain.Entities.Social;

    public class TopicFullViewModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public DateTime CreateOn { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<string> TopicTicketsIds { get; set; }

        public Queue<string> CommentTicketsIds { get; set; }
    }
}
