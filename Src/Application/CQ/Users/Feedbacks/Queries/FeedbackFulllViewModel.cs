namespace Application.CQ.Users.Feedbacks.Queries
{
    using System;

    public class FeedbackFulllViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Stars { get; set; }

        public int Rate { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime SentOn { get; set; }
    }
}
