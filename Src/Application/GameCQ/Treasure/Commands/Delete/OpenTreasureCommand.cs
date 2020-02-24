namespace Application.GameCQ.Treasure.Commands.Delete
{
    using MediatR;

    public class OpenTreasureCommand : IRequest
    {
        public int Id { get; set; }

        public int Reward { get; set; }

        public string Rarity { get; set; }
    }
}
