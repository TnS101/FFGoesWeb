namespace Application.CQ.Social.FriendRequests.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalFriendRequestsQuery : IRequest<FriendRequestListViewModel>
    {
        public ClaimsPrincipal Reciever { get; set; }
    }
}
