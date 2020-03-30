namespace Application.CQ.Social.Comments.Commands.Create
{
    using MediatR;

    public class EditCommentCommand : IRequest<string>
    {
        public string CommentId { get; set; }

        public string Content { get; set; }
    }
}
