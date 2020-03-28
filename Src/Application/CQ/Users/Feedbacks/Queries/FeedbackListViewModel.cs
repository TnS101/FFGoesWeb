namespace Application.CQ.Users.Feedbacks.Queries
{
    using System.Collections.Generic;

    public class FeedbackListViewModel
    {
        public IEnumerable<FeedbackFulllViewModel> Feedbacks { get; set; }
    }
}
