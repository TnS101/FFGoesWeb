namespace Application.CQ.Social.Likes.Command.Delete
{
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

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
                var likeToRemove = await this.context.Likes.FirstOrDefaultAsync(l => l.CommentId == request.CommentId && l.UserId == user.Id);

                this.context.Likes.Remove(likeToRemove);
            }
            else
            {
                var likeToRemove = await this.context.Likes.FirstOrDefaultAsync(l => l.TopicId == request.TopicId && l.UserId == user.Id);

                this.context.Likes.Remove(likeToRemove);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TopicCommandRedirect;
        }
    }
}
