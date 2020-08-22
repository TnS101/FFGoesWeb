namespace Application.CQ.Social.Likes.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class LeaveLikeCommandHandler : BaseHandler, IRequestHandler<LeaveLikeCommand, string>
    {
        public LeaveLikeCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(LeaveLikeCommand request, CancellationToken cancellationToken)
        {
            if (request.CommentId != null)
            {
                if (this.Context.Comments.Any(c => c.Id == request.CommentId && c.UserId == request.UserId)
                   || await this.Context.Likes.AnyAsync(l => l.CommentId == request.CommentId && l.UserId == request.UserId))
                {
                    return GConst.ErrorRedirect;
                }

                this.Context.Likes.Add(new Like
                {
                    CommentId = request.CommentId,
                    UserId = request.UserId,
                });
            }
            else
            {
                if (this.Context.Topics.Any(t => t.Id == request.TopicId && t.UserId == request.UserId)
                    || await this.Context.Likes.AnyAsync(l => l.TopicId == request.TopicId && l.UserId == request.UserId))
                {
                    return GConst.ErrorRedirect;
                }

                this.Context.Likes.Add(new Like
                {
                    TopicId = request.TopicId,
                    UserId = request.UserId,
                });
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
