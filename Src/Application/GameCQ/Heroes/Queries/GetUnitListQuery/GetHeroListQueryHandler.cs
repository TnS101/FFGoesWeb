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

            foreach (var hero in heroes.ToList())
            {
                if (hero.Energy < 15 && DateTime.UtcNow.Second - hero.LastEnergyChange.Second >= 10)
                {
                    hero.Energy++;
                    hero.LastEnergyChange = DateTime.UtcNow;
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
