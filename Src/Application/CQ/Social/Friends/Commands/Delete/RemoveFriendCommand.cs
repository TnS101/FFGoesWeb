namespace Application.CQ.Social.Friends.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class RemoveFriendCommand : IRequest<string>
    {
        public string FriendId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
