namespace Application.CQ.Forum.FriendRequest.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class AcceptFriendRequestCommand : IRequest<string>
    {
        public ClaimsPrincipal Reciever { get; set; }

        public string RequestId { get; set; }
    }
}
