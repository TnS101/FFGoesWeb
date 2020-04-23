namespace Application.CQ.Social.FriendRequests.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteFriendRequestCommandHandler : BaseHandler, IRequestHandler<DeleteFriendRequestCommand, string>
    {
        public DeleteFriendRequestCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var requestToDelete = await this.Context.FriendRequests.FindAsync(request.RequestId);

            this.Context.FriendRequests.Remove(requestToDelete);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}
