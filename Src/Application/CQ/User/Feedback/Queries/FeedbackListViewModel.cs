namespace Application.CQ.User.Feedback.Queries
{
    using System.Collections.Generic;

    public class FeedbackListViewModel
    {
        public IEnumerable<FeedbackPartialViewModel> Feedbacks { get; set; }
    }
}
