namespace Application.CQ.Social.FriendRequests.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class AcceptFriendRequestCommand : IRequest<string>
    {
        public ClaimsPrincipal Reciever { get; set; }

        public int RequestId { get; set; }
    }
}
