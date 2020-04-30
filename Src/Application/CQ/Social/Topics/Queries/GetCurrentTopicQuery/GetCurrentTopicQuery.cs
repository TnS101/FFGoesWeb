namespace Application.CQ.Social.Topics.Queries.GetCurrentTopicQuery
{
    using MediatR;
    using System.Security.Claims;

    public class GetCurrentTopicQuery : IRequest<TopicFullViewModel>
    {
        public string TopicId { get; set; }

        public string UserId { get; set; }
    }
}
