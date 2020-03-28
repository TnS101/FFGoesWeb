namespace Application.GameCQ.Battles.Commands.Update
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using MediatR;

    public class BattleOptionsCommand : IRequest<string>
    {
        public UnitFullViewModel Player { get; set; }

        public UnitFullViewModel Enemy { get; set; }

        public string Command { get; set; }

        public bool YourTurn { get; set; }

        public string SpellName { get; set; }
    }
}
