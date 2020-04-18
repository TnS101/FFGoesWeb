namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using MediatR;

    public class GetCurrentTopicQuery : IRequest<TopicFullViewModel>
    {
        public string TopicId { get; set; }
    }
}
