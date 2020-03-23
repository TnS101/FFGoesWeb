namespace Application.CQ.User.Feedback.Queries
{
    using System;

    public class FeedbackPartialViewModel
    {
        public string Content { get; set; }

        public int Stars { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime SentOn { get; set; }
    }
}
