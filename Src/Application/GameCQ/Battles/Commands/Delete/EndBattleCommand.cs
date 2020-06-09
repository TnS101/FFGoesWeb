namespace Application.GameCQ.Battles.Commands.Delete
{
    using Domain.Entities.Game.Units;
    using MediatR;

    public class EndBattleCommand : IRequest<long>
    {
        public long HeroId { get; set; }

        public string ZoneName { get; set; }

        public Monster Monster { get; set; }
    }
}
