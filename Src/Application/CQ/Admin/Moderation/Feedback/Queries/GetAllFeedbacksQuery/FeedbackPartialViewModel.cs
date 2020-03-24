namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System;

    public class FeedbackPartialViewModel
    {
        public string Id { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }
    }
}
