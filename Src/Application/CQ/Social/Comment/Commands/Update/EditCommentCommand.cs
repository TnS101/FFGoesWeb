namespace Application.CQ.Forum.Comment.Update
{
    using MediatR;

    public class EditCommentCommand : IRequest<string>
    {
        public int CommentId { get; set; }

        public string Content { get; set; }
    }
}
