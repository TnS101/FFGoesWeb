namespace Application.CQ.Users.Feedbacks.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalFeedbacksQuery : IRequest<FeedbackListViewModel>
    {
        public string UserId { get; set; }
    }
}
