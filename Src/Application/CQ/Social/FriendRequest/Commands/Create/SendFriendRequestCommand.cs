namespace Application.CQ.Forum.FriendRequest.Commands.Create
{
    using System;
    using System.Security.Claims;
    using MediatR;

    public class SendFriendRequestCommand : IRequest<string>
    {
        public ClaimsPrincipal Sender { get; set; }

        public string RecieverId { get; set; }
    }
}
