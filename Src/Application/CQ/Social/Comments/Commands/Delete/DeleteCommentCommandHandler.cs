namespace Application.CQ.Social.Comments.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteCommentCommandHandler : BaseHandler, IRequestHandler<DeleteCommentCommand, string>
    {
        public DeleteCommentCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToRemove = await this.Context.Comments.FindAsync(request.CommentId);

            var replies = this.Context.Comments.Where(c => c.Replies.Select(r => r.Id == commentToRemove.Id).Count() > 0);

            this.Context.Comments.RemoveRange(replies);

            await this.Context.SaveChangesAsync(cancellationToken);

            this.Context.Comments.Remove(commentToRemove);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CommentCommandRedirect, commentToRemove.TopicId);
        }
    }
}
