namespace Domain.Entities.Social
{
    using Domain.Entities.Common;
    using System;

    public class Like
    {
        public Like()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public string TopicId { get; set; }

        public Topic Topic { get; set; }

        public string CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
