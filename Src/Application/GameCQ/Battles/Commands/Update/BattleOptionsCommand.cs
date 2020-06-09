namespace Application.GameCQ.Battles.Commands.Update
{
    using Application.GameCQ.Battles.Queries.GetBattleUnitsQuery;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class BattleOptionsCommand : IRequest<string>
    {
        public long HeroId { get; set; }

        public Monster Enemy { get; set; }

        public string Command { get; set; }

        public bool YourTurn { get; set; }

        public int SpellId { get; set; }

        public string ZoneName { get; set; }
    }
}
