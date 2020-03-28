namespace Application.CQ.Social.FriendRequests.Commands.Delete
{
    using MediatR;

    public class DeleteFriendRequestCommand : IRequest<string>
    {
        public int RequestId { get; set; }
    }
}
