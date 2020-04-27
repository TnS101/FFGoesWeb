namespace Application.CQ.Social.Likes.Commands.Create
{
    using System.Security.Claims;
    using MediatR;

    public class LeaveLikeCommand : IRequest<string>
    {
        public string TopicId { get; set; }

        public string CommentId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
