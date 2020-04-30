namespace Application.CQ.Social.FriendRequests.Queries
{
    using MediatR;

    public class GetPersonalFriendRequestsQuery : IRequest<FriendRequestListViewModel>
    {
        public string UserId { get; set; }
    }
}
