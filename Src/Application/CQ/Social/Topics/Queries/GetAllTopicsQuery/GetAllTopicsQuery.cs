namespace Application.CQ.Social.Topics.Queries.GetAllTopicsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetAllTopicsQuery : IRequest<TopicListViewModel>
    {
        public string UserId { get; set; }

        public string[] Filter { get; set; }
    }
}
