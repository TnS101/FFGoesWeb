namespace Application.CQ.Social.Likes.Command.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class DislikeCommand : IRequest<string>
    {
        public string CommentId { get; set; }

        public string TopicId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
