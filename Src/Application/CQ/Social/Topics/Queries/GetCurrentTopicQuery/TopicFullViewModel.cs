namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Application.Common.RegexFilters;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using global::Common;

    public class TopicFullViewModel : RegexFilter
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(20, ErrorMessage = GConst.LengthMessage, MinimumLength = 5)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        [ContentFilter(GConst.ContentFilter, ErrorMessage = GConst.ContentMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        public string Category { get; set; }

        [StringLength(200, ErrorMessage = GConst.LengthMessage, MinimumLength = 20)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        public string Content { get; set; }

        public DateTime CreateOn { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<string> TopicTicketsIds { get; set; }

        public ICollection<Like> Likes { get; set; }

        public Queue<string> CommentTicketsIds { get; set; }
    }
}
