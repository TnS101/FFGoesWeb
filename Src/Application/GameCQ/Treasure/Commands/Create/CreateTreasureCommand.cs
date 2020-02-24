namespace Application.GameCQ.Treasure.Commands.Create
{
    using MediatR;

    public class CreateTreasureCommand : IRequest
    {
        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImageURL { get; set; }
    }
}
