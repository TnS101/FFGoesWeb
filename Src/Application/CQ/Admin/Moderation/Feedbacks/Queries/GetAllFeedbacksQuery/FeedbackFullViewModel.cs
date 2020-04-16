namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery
{
    using System;

    public class FeedbackFullViewModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public int Rate { get; set; }
    }
}
