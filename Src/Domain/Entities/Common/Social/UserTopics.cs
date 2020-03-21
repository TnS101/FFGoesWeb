namespace Domain.Entities.Common.Social
{
    public class UserTopics
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}
