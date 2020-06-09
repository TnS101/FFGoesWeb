namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class GetBattleUnitsQuery : IRequest<BattleUnitsListViewModel>
    {
        public long HeroId { get; set; }

        public Monster Enemy { get; set; }
    }
}
