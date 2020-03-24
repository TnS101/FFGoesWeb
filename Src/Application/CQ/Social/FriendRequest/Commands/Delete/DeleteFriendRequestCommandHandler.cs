﻿namespace Application.CQ.Forum.FriendRequest.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteFriendRequestCommandHandler : IRequestHandler<DeleteFriendRequestCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteFriendRequestCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var requestToDelete = await this.context.FriendRequests.FindAsync(request.RequestId);

            this.context.FriendRequests.Remove(requestToDelete);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FriendCommandRedirect;
        }
    }
}