namespace Application.CQ.Users.Statuses.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UpdateStatusCommandHandler : BaseHandler, IRequestHandler<UpdateStatusCommand, string>
    {
        public UpdateStatusCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var userStatus = await this.Context.UserStatuses.SingleOrDefaultAsync(us => us.UserId == user.Id);

            this.Context.UserStatuses.Remove(userStatus);

            if (request.StatusId == 0)
            {
                return $"{GConst.ProfileRedirect}#statuses";
            }

            this.Context.UserStatuses.Add(new UserStatus
            {
                StatusId = request.StatusId,
                UserId = user.Id,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return $"{GConst.ProfileRedirect}#statuses";
        }
    }
}
