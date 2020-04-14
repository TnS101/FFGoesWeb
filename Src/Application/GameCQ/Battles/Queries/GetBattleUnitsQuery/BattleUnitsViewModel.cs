namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class BattleUnitsViewModel
    {
        public UnitFullViewModel Hero { get; set; }

        public UnitFullViewModel Enemy { get; set; }
    }
}
