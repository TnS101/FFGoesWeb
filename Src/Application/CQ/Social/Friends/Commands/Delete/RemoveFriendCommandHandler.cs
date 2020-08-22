namespace Application.CQ.Social.Friends.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class RemoveFriendCommandHandler : BaseHandler, IRequestHandler<RemoveFriendCommand, string>
    {
        public RemoveFriendCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(RemoveFriendCommand request, CancellationToken cancellationToken)
        {
            var friend = await this.Context.Friends.FirstOrDefaultAsync(f => f.Id == request.FriendId);

            var userFriend = await this.Context.Friends.FirstOrDefaultAsync(f => f.Id == request.UserId);

            this.Context.Friends.Remove(friend);

            this.Context.Friends.Remove(userFriend);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
