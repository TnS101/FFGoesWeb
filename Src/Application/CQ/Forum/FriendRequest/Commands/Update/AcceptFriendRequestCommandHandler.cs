namespace Application.CQ.Forum.FriendRequest.Commands.Update
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class AcceptFriendRequestCommandHandler : IRequestHandler<AcceptFriendRequestCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public AcceptFriendRequestCommandHandler(IFFDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var friendRequest = await this.context.FriendRequests.FindAsync(request.RequestId);

            var friend = await this.context.Users.FindAsync(friendRequest.UserId);

            user.Friends.Add(friend);

            this.context.FriendRequests.Remove(friendRequest);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
