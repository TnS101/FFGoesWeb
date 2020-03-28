namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetAllFeedbacksQuery.ToDoList
{
    using System.Collections.Generic;

    public class FeedbackTaskListViewModel
    {
        public IEnumerable<FeedbackTaskViewModel> Tasks { get; set; }
    }
}
