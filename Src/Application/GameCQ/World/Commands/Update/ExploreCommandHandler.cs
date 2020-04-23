namespace Application.GameCQ.World.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class ExploreCommandHandler : UserHandler, IRequestHandler<ExploreCommand, string>
    {
        public ExploreCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(ExploreCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var user = await this.UserManager.GetUserAsync(request.User);

            int exploreNumber = rng.Next(0, 10);

            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            if (hero.Energy == 0)
            {
                return GConst.NotEnoughEnergyRedirect;
            }

            hero.Energy--;

            this.Context.EnergyChanges.Add(new EnergyChange
            {
                HeroId = hero.Id,
                Type = "Walk",
                LastChangedOn = DateTime.UtcNow,
            });

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            // if (exploreNumber == 0 || exploreNumber == 1)
            // {
            //     return GConst.TreasureEncounterRedirect;
            // }
            // else
            // {}
            return GConst.EnemyEncounterRedirect;
        }
    }
}
