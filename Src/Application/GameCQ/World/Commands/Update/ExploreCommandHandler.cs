namespace Application.GameCQ.World.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ExploreCommandHandler : BaseHandler, IRequestHandler<ExploreCommand, string>
    {
        public ExploreCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(ExploreCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            int exploreNumber = rng.Next(10);

            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.UserId == request.UserId && h.IsSelected);

            if (hero.Energy == 0)
            {
                return GConst.HeroCommandRedirect;
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
