namespace Application.CQ.Forum.FriendRequest.Commands.Create
{
    using MediatR;
    using System;
    using System.Security.Claims;

    public class SendFriendRequestCommand : IRequest<string>
    {
        public ClaimsPrincipal Sender { get; set; }

        public string RecieverId { get; set; }
    }
}
