namespace Application.GameCQ.World.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class ExploreCommandHandler : IRequestHandler<ExploreCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public ExploreCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(ExploreCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var user = await this.userManager.GetUserAsync(request.User);

            int exploreNumber = rng.Next(0, 10);

            var hero = await this.context.Heroes.FirstOrDefaultAsync(h => h.UserId == user.Id && h.IsSelected);

            if (hero.Energy == 0)
            {
                return GConst.NotEnoughEnergyRedirect;
            }

            hero.Energy--;

            await this.context.EnergyChanges.AddAsync(new EnergyChange
            {
                HeroId = hero.Id,
                Type = "Walk",
                LastChangedOn = DateTime.UtcNow,
            });

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            //if (exploreNumber == 0 || exploreNumber == 1)
            //{
            //    return GConst.TreasureEncounterRedirect;
            //}
            //else
            //{
            //    
            //}

            return GConst.EnemyEncounterRedirect;
        }
    }
}
