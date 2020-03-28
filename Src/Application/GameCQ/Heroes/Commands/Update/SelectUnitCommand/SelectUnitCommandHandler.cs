namespace Application.GameCQ.Unit.Commands.Update.SelectUnitCommand
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SelectUnitCommandHandler : IRequestHandler<SelectUnitCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public SelectUnitCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(SelectUnitCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            if (this.context.Heroes.Where(u => u.UserId == user.Id).Any(u => u.IsSelected))
            {
                var oldUnit = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

                oldUnit.IsSelected = false;

                this.context.Heroes.Update(oldUnit);
            }

            var unit = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.Name == request.Id);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
