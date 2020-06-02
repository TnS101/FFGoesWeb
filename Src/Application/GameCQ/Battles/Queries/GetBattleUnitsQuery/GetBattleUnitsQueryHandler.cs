namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using System.Linq;
    using Application.Common.Interfaces;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;
    using AutoMapper;
    using MediatR;

    public class GetBattleUnitsQueryHandler : RequestHandler<GetBattleUnitsQuery, BattleUnitsViewModel>
    {
        private readonly IMapper mapper;
        private readonly IFFDbContext context;

        public GetBattleUnitsQueryHandler(IMapper mapper, IFFDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        protected override BattleUnitsViewModel Handle(GetBattleUnitsQuery request)
        {
            var hero = request.Hero;

            foreach (var spell in this.context.Spells.Where(s => s.FightingClassId == hero.FightingClassId))
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
