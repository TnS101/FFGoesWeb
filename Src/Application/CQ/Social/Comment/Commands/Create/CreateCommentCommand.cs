namespace Application.CQ.Forum.Comment.Create
{
    using System.Security.Claims;
    using MediatR;

    public class CreateCommentCommand : IRequest<string>
    {
        public string Content { get; set; }

        public int TopicId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
