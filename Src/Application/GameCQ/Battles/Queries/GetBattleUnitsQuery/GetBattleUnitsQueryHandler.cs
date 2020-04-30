namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using Application.Common.Interfaces;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using AutoMapper;
    using MediatR;
    using System.Linq;

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

            foreach (var spell in this.context.Spells.Where(s => s.ClassType == hero.ClassType))
            {
                hero.Spells.Add(spell);
            }

            return new BattleUnitsViewModel
            {
                Hero = request.Hero,
                Enemy = this.mapper.Map<UnitFullViewModel>(request.Enemy),
            };
        }
    }
}
