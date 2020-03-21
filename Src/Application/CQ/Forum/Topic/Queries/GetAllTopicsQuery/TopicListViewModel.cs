namespace Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery
{
    using System.Collections.Generic;

    public class TopicListViewModel
    {
        public IEnumerable<TopicPartialViewModel> Topics { get; set; }
    }
}
