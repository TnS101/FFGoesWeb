namespace Application.CQ.User.Feedbacks.Queries
{
    using System.Collections.Generic;

    public class FeedbackListViewModel
    {
        public IEnumerable<FeedbackFulllViewModel> Feedbacks { get; set; }
    }
}
