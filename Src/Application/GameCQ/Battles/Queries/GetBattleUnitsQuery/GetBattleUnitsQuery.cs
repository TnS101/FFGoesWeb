namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class GetBattleUnitsQuery : IRequest<BattleUnitsViewModel>
    {
        public UnitFullViewModel Hero { get; set; }

        public Monster Enemy { get; set; }
    }
}
