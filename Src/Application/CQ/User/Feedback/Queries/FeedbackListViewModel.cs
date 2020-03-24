namespace Application.CQ.User.Feedback.Queries
{
    using System.Collections.Generic;

    public class FeedbackListViewModel
    {
        public IEnumerable<FeedbackFulllViewModel> Feedbacks { get; set; }
    }
}
