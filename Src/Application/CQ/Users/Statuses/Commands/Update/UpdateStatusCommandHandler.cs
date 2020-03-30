namespace Application.CQ.Users.Statuses.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Domain.Entities.Common.Social;

    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, string>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFFDbContext context;

        public UpdateStatusCommandHandler(UserManager<AppUser> userManager, IFFDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<string> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var userStatus = await this.context.UserStatuses.SingleOrDefaultAsync(us => us.UserId == user.Id);

            this.context.UserStatuses.Remove(userStatus);

            if (request.StatusId == 0)
            {
                return GConst.ProfileRedirect;
            }

            this.context.UserStatuses.Add(new UserStatus
            {
                StatusId = request.StatusId,
                UserId = user.Id,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.ProfileRedirect;
        }
    }
}
