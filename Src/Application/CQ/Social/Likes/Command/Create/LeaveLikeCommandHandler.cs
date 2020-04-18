namespace Application.CQ.Social.Likes.Command.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

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
                this.context.Likes.Add(new Like
                {
                    CommentId = request.CommentId,
                    UserId = user.Id,
                });
            }
            else
            {
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
