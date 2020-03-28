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

            var status = this.context.Statuses.FirstOrDefault(s => s.DisplayName == request.StatusName);

            var userStatus = this.context.UserStatuses.FirstOrDefault(us => us.UserId == user.Id);

            this.context.UserStatuses.Remove(userStatus);

            await this.context.SaveChangesAsync(cancellationToken);

            this.context.UserStatuses.Add(new Domain.Entities.Common.Social.UserStatus
            {
                UserId = user.Id,
                StatusId = status.Id,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.ProfileRedirect;
        }
    }
}
