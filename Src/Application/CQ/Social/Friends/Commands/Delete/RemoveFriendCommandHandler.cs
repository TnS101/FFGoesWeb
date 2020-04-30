namespace Application.CQ.Social.Friends.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class RemoveFriendCommandHandler : BaseHandler, IRequestHandler<RemoveFriendCommand, string>
    {
        public RemoveFriendCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(RemoveFriendCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var friend = await this.Context.Friends.FirstOrDefaultAsync(f => f.Id == request.FriendId);

            var userFriend = await this.Context.Friends.FirstOrDefaultAsync(f => f.Id == user.Id);

            this.Context.Friends.Remove(friend);

            this.Context.Friends.Remove(userFriend);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
