namespace Application.CQ.Forum.Topic.Queries.GetAllTopicsQuery
{
    using MediatR;
    using System.Security.Claims;

    public class GetAllTopicsQuery : IRequest<TopicListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
