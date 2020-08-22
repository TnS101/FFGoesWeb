namespace Application.CQ.Social.Likes.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DislikeCommandHandler : BaseHandler, IRequestHandler<DislikeCommand, string>
    {
        public DislikeCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DislikeCommand request, CancellationToken cancellationToken)
        {
            if (request.CommentId != null)
            {
                if (this.Context.Comments.Any(c => c.Id == request.CommentId && c.UserId != request.UserId)
                    && this.Context.Likes.Any(l => l.CommentId == request.CommentId && l.UserId == request.UserId))
                {
                    var likeToRemove = await this.Context.Likes.FirstOrDefaultAsync(l => l.CommentId == request.CommentId && l.UserId == request.UserId);

                    this.Context.Likes.Remove(likeToRemove);
                }
                else
                {
                    return GConst.ErrorRedirect;
                }
            }
            else
            {
                if (this.Context.Topics.Any(t => t.Id == request.TopicId && t.UserId != request.UserId)
                    && this.Context.Likes.Any(l => l.TopicId == request.TopicId && l.UserId == request.UserId))
                {
                    var likeToRemove = await this.Context.Likes.FirstOrDefaultAsync(l => l.TopicId == request.TopicId && l.UserId == request.UserId);

                    this.Context.Likes.Remove(likeToRemove);
                }
                else
                {
                    return GConst.ErrorRedirect;
                }
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
