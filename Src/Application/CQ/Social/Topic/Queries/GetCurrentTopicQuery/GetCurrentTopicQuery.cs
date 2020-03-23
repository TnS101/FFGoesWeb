namespace Application.CQ.Forum.Topic.Queries.GetCurrentTopicQuery
{
    using MediatR;

    public class GetCurrentTopicQuery : IRequest<TopicFullViewModel>
    {
        public string TopicId { get; set; }
    }
}
