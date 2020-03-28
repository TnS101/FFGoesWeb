namespace Application.GameCQ.Heroes.Commands.Update.SelectHeroCommand
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

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

            if (this.context.Heroes.Where(u => u.UserId == user.Id).Any(u => u.IsSelected))
            {
                var oldHero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

                oldHero.IsSelected = false;

                this.context.Heroes.Update(oldHero);
            }

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.Id == request.Id);

            hero.IsSelected = true;

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.UnitCommandRedirect;
        }
    }
}
