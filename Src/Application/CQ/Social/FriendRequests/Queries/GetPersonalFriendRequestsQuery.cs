namespace Application.CQ.Social.FriendRequest.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalFriendRequestsQuery : IRequest<FriendRequestListViewModel>
    {
        public int RequestId { get; set; }

        public ClaimsPrincipal Reciever { get; set; }
    }
}
