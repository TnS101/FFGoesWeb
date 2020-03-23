namespace Application.CQ.Forum.FriendRequest.Queries
{
    using MediatR;
    using System.Security.Claims;

    public class GetPersonalFriendRequestsQuery : IRequest<FriendRequestListViewModel>
    {
        public string RequestId { get; set; }

        public ClaimsPrincipal Reciever { get; set; }
    }
}
