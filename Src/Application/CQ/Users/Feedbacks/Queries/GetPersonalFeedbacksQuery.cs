namespace Application.CQ.Users.Feedbacks.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalFeedbacksQuery : IRequest<FeedbackListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
