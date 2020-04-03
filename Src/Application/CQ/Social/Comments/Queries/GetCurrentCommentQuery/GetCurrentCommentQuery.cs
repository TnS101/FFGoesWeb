namespace Application.CQ.Social.Comments.Queries.GetCurrentCommentQuery
{
    using MediatR;

    public class GetCurrentCommentQuery : IRequest<CommentMinViewModel>
    {
        public string CommentId { get; set; }
    }
}
