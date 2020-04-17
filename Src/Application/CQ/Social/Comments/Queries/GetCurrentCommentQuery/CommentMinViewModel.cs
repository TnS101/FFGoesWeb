namespace Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery
{
    using System.Collections.Generic;
    using Domain.Entities.Social;

    public class CommentMinViewModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public virtual Comment Reply { get; set; }

        public virtual ICollection<Comment> Replies { get; set; }
    }
}
