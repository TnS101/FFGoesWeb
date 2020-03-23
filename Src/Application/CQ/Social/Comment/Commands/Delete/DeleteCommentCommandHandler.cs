namespace Application.CQ.Forum.Comment.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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

            this.context.Comments.RemoveRange(commentToRemove.Replies);

            this.context.Comments.Remove(commentToRemove);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect,request.TopicId);
        }
    }
}
