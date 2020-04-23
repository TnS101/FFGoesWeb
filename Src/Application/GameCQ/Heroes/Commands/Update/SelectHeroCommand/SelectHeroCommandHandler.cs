namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
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

    public class SelectHeroCommandHandler : UserHandler, IRequestHandler<SelectHeroCommand, string>
    {
        public SelectHeroCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(SelectHeroCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var oldHero = await this.Context.Heroes.FirstOrDefaultAsync(u => u.UserId == user.Id && u.IsSelected);

            if (oldHero != null)
            {
                oldHero.IsSelected = false;

                this.Context.Heroes.Update(oldHero);
            }

            var hero = await this.Context.Heroes.FindAsync(request.UnitId);

            hero.IsSelected = true;

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }
    }
}
