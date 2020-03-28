namespace Application.CQ.Social.Comments.Commands.Create
{
    using MediatR;

    public class DeleteCommentCommand : IRequest<string>
    {
        public int CommentId { get; set; }
    }
}
