namespace Application.CQ.Social.Friends.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class RemoveFriendCommandHandler : IRequestHandler<RemoveFriendCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public RemoveFriendCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(RemoveFriendCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var friend = await this.context.AppUsers.FindAsync(request.FriendId);

            user.Friends.Remove(friend);

            this.context.AppUsers.Update(friend);

            return GConst.FriendCommandRedirect;
        }
    }
}
