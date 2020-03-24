namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System;

    public class FeedbackPartialViewModel
    {
        public string SenderName { get; set; }

        public int Rate { get; set; }

        public DateTime SentOn { get; set; }
    }
}
