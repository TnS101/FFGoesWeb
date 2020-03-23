namespace Application.CQ.Forum.Comment.Delete
{
    using MediatR;

    public class DeleteCommentCommand : IRequest<string>
    {
        public string CommentId { get; set; }

        public string TopicId { get; set; }
    }
}
