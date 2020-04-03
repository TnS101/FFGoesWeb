namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetHeroListQueryHandler : IRequestHandler<GetHeroListQuery, HeroListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public GetHeroListQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<HeroListViewModel> Handle(GetHeroListQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var heroes = this.context.Heroes.Where(h => h.UserId == user.Id);

            foreach (var hero in heroes)
            {
                foreach (var energyChange in this.context.EnergyChanges.Where(ec => ec.HeroId == hero.Id).OrderBy(l => l.LastChangedOn).ToList())
                {
                    if (hero.Energy < 30 && DateTime.UtcNow.Minute - energyChange.LastChangedOn.Minute >= 4)
                    {
                        hero.Energy++;
                        this.context.EnergyChanges.Remove(energyChange);

                        await this.context.EnergyChanges.AddAsync(new EnergyChange
                        {
                            HeroId = hero.Id,
                            LastChangedOn = DateTime.UtcNow,
                            Type = "Regenerate",
                        });
                    }

                    if (hero.Energy == 30)
                    {
                        this.context.EnergyChanges.RemoveRange(this.context.EnergyChanges.Where(ec => ec.HeroId == hero.Id));
                    }
                }

                this.context.Heroes.Update(hero);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return new HeroListViewModel
            {
                Heroes = await heroes.ProjectTo<HeroMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }
    }
}
