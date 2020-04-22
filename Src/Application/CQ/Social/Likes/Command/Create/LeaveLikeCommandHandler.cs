namespace Application.CQ.Social.Likes.Command.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class LeaveLikeCommandHandler : IRequestHandler<LeaveLikeCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public LeaveLikeCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(LeaveLikeCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (request.CommentId != null)
            {
                if (this.context.Comments.Any(c => c.Id == request.CommentId && c.UserId == user.Id)
                   || await this.context.Likes.AnyAsync(l => l.CommentId == request.CommentId && l.UserId == user.Id))
                {
                    return GConst.ErrorRedirect;
                }

                this.context.Likes.Add(new Like
                {
                    CommentId = request.CommentId,
                    UserId = user.Id,
                });
            }
            else
            {
                if (this.context.Topics.Any(t => t.Id == request.TopicId && t.UserId == user.Id)
                    || await this.context.Likes.AnyAsync(l => l.TopicId == request.TopicId && l.UserId == user.Id))
                {
                    return GConst.ErrorRedirect;
                }

                this.context.Likes.Add(new Like
                {
                    TopicId = request.TopicId,
                    UserId = user.Id,
                });
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
