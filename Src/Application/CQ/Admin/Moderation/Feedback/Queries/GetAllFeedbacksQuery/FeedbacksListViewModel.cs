namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System.Collections.Generic;

    public class FeedbacksListViewModel
    {
        public IEnumerable<FeedbackPartialViewModel> Feedbacks { get; set; }
    }
}
