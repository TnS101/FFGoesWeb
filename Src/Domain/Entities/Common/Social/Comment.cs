namespace Domain.Entities.Common.Social
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment 
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Replies = new HashSet<Comment>();
        }
        public string Id { get; set; }

        public string ReplyId { get; set; }

        [ForeignKey("ReplyId")]
        public virtual Comment Reply { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string TopicId { get; set; }

        public Topic Topic { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Comment> Replies { get; set; }
    }
}
