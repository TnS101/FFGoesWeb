namespace Application.CQ.Social.Topics.Queries.GetAllTopicsQuery
{
    using System.Collections.Generic;

    public class TopicListViewModel
    {
        public IEnumerable<TopicPartialViewModel> Topics { get; set; }

        public string ViewerId { get; set; }
    }
}
