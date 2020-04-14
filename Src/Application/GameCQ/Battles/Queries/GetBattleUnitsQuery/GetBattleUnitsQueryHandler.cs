namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using AutoMapper;
    using MediatR;

    public class GetBattleUnitsQueryHandler : RequestHandler<GetBattleUnitsQuery, BattleUnitsViewModel>
    {
        private readonly IMapper mapper;

        public GetBattleUnitsQueryHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected override BattleUnitsViewModel Handle(GetBattleUnitsQuery request)
        {
            return new BattleUnitsViewModel
            {
                Hero = request.Hero,
                Enemy = this.mapper.Map<UnitFullViewModel>(request.Enemy),
            };
        }
    }
}
