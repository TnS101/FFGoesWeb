namespace Application.CQ.Social.Likes.Command.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DislikeCommandHandler : IRequestHandler<DislikeCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public DislikeCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(DislikeCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (request.CommentId != null)
            {
                if (this.context.Comments.Any(c => c.Id == request.CommentId && c.UserId == user.Id)
                    && await this.context.Likes.AnyAsync(l => l.CommentId == request.CommentId && l.UserId == user.Id))
                {
                    var likeToRemove = await this.context.Likes.FirstOrDefaultAsync(l => l.CommentId == request.CommentId && l.UserId == user.Id);

                    this.context.Likes.Remove(likeToRemove);
                }
                else
                {
                    return GConst.ErrorRedirect;
                }
            }
            else
            {
                if (this.context.Topics.Any(t => t.Id == request.TopicId && t.UserId == user.Id)
                    && await this.context.Likes.AnyAsync(l => l.TopicId == request.TopicId && l.UserId == user.Id))
                {
                    var likeToRemove = await this.context.Likes.FirstOrDefaultAsync(l => l.TopicId == request.TopicId && l.UserId == user.Id);

                    this.context.Likes.Remove(likeToRemove);
                }
                else
                {
                    return GConst.ErrorRedirect;
                }
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
