namespace Application.CQ.Forum.FriendRequest.Commands.Delete
{
    using MediatR;

    public class DeleteFriendRequestCommand : IRequest<string>
    {
        public string RequestId { get; set; }
    }
}
