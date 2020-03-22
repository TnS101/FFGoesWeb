namespace Application.CQ.Forum.Comment.Update
{
    using MediatR;

    public class EditCommentCommand : IRequest<string>
    {
        public string CommentId { get; set; }

        public string Content { get; set; }

        public string TopicId { get; set; }
    }
}
