namespace Application.CQ.Social.FriendRequests.Commands.Update
{
    using MediatR;

    public class AcceptFriendRequestCommand : IRequest<string>
    {
        public string UserId { get; set; }

        public int RequestId { get; set; }
    }
}
