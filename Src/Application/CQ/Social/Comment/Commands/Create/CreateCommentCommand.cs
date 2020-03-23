namespace Application.CQ.Forum.Comment.Create
{
    using MediatR;
    using System.Security.Claims;

    public class CreateCommentCommand : IRequest<string>
    {
        public string Content { get; set; }

        public string TopicId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
