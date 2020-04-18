namespace Application.CQ.Social.Likes.Queries
{
    using MediatR;

    public class GetAllLikesQuery : IRequest<LikesListViewModel>
    {
        public string TopicId { get; set; }

        public string CommentId { get; set; }
    }
}
