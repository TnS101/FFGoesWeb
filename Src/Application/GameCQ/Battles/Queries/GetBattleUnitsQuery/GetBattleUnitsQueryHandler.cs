namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetBattleUnitsQueryHandler : IRequestHandler<GetBattleUnitsQuery, BattleUnitsViewModel>
    {
        private readonly IMapper mapper;
        private readonly IFFDbContext context;

        public GetBattleUnitsQueryHandler(IMapper mapper, IFFDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<BattleUnitsViewModel> Handle(GetBattleUnitsQuery request, CancellationToken cancellationToken)
        {
            var hero = request.Hero;

            foreach (var spell in await this.context.Spells.Where(s => s.FightingClassId == hero.FightingClassId).ToListAsync())
            {
                hero.Spells.Add(this.mapper.Map<SpellMinViewModel>(spell));
            }

            return new BattleUnitsViewModel
            {
                Hero = request.Hero,
                Enemy = this.mapper.Map<UnitFullViewModel>(request.Enemy),
            };
        }
    }
}
