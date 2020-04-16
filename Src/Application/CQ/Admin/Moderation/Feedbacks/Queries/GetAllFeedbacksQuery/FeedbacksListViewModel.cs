namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery
{
    using System.Collections.Generic;
    using Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery;

    public class FeedbacksListViewModel
    {
        public IEnumerable<FeedbackFullViewModel> Feedbacks { get; set; }
    }
}
