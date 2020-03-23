namespace Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetAllTopicsQuery : IRequest<TopicListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
