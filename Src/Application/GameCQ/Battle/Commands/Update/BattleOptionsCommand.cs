namespace Application.GameCQ.Battle.Commands.Update
{
    using Application.GameCQ.Unit.Queries;
    using MediatR;

    public class BattleOptionsCommand : IRequest<string>
    {
        public UnitFullViewModel Player { get; set; }

        public FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Unit Enemy { get; set; }

        public string Command { get; set; }

        public bool YourTurn { get; set; }
    }
}
