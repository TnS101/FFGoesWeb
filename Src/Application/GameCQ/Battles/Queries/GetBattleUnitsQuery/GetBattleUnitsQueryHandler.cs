namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetBattleUnitsQueryHandler : MapperHandler, IRequestHandler<GetBattleUnitsQuery, BattleUnitsListViewModel>
    {
        public GetBattleUnitsQueryHandler(IMapper mapper, IFFDbContext context)
            : base(context, mapper)
        {
        }

        public async Task<BattleUnitsListViewModel> Handle(GetBattleUnitsQuery request, CancellationToken cancellationToken)
        {
            var dbHero = await this.Context.Heroes.FindAsync(request.HeroId);

            var hero = this.Mapper.Map<BattleUnitViewModel>(dbHero);

            foreach (var spell in await this.Context.Spells.Where(s => s.FightingClassId == dbHero.FightingClassId).ToListAsync())
            {
                hero.Spells.Add(this.Mapper.Map<SpellMinViewModel>(spell));
            }

            return new BattleUnitsListViewModel
            {
                Hero = hero,
                Enemy = this.Mapper.Map<BattleUnitViewModel>(request.Enemy),
            };
        }
    }
}
