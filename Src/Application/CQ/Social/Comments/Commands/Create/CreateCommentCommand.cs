namespace Application.CQ.Social.Comments.Commands.Create
{
    using System.Security.Claims;
    using MediatR;

    public class CreateCommentCommand : IRequest<string>
    {
        public string Content { get; set; }

        public string TopicId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
