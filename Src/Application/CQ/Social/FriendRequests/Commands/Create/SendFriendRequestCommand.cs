namespace Application.CQ.Social.FriendRequests.Commands.Create
{
    using MediatR;

    public class SendFriendRequestCommand : IRequest<string>
    {
        public string UserId { get; set; }

        public string RecieverId { get; set; }
    }
}
