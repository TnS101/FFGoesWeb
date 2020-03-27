namespace Application.CQ.Forum.Comment.Delete
{
    using MediatR;

    public class DeleteCommentCommand : IRequest<string>
    {
        public int CommentId { get; set; }

        public int TopicId { get; set; }
    }
}
