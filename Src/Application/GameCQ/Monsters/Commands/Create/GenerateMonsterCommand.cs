namespace Application.GameCQ.Monsters.Commands.Create
{
    using Domain.Entities.Game.Units;
    using MediatR;

    public class GenerateMonsterCommand : IRequest<Monster>
    {
        public int PlayerLevel { get; set; }

        public string ZoneName { get; set; }
    }
}
