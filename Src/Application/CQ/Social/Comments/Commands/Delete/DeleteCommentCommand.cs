namespace Application.CQ.Social.Comments.Commands.Create
{
    using MediatR;

    public class DeleteCommentCommand : IRequest<string>
    {
        public string CommentId { get; set; }
    }
}
