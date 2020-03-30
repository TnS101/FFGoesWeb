namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class SelectHeroCommandHandler : IRequestHandler<SelectHeroCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public SelectHeroCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(SelectHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var oldHero = await this.context.Heroes.FirstOrDefaultAsync(u => u.UserId == user.Id);

            if (oldHero.IsSelected)
            {
                oldHero.IsSelected = false;

                this.context.Heroes.Update(oldHero);
            }

            Hero hero = await this.context.Heroes.FindAsync(request.UnitId);

            hero.IsSelected = true;

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
