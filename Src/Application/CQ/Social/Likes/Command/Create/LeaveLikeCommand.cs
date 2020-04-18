namespace Application.CQ.Social.Likes.Command.Create
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
