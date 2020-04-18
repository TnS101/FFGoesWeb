namespace Application.CQ.Social.Topics.Queries.GetAllTopicsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetAllTopicsQuery : IRequest<TopicListViewModel>
    {
        public ClaimsPrincipal User { get; set; }

        public string[] Filter { get; set; }
    }
}
