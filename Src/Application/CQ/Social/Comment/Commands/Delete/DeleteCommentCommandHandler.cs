namespace Application.CQ.Forum.Comment.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteCommentCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToRemove = this.context.Comments.FirstOrDefault(c => c.Id == request.CommentId);

            var replies = this.context.Comments.Where(c => c.Replies.Select(r => r.Id == commentToRemove.Id).Count() > 0);

            this.context.Comments.RemoveRange(replies);

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.Comments.Remove(commentToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect, request.TopicId);
        }
    }
}
