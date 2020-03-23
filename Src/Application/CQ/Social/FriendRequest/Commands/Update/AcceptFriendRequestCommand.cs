namespace Application.CQ.Forum.FriendRequest.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class AcceptFriendRequestCommand : IRequest<string>
    {
        public ClaimsPrincipal Reciever { get; set; }

        public string RequestId { get; set; }
    }
}
