namespace Application.GameCQ.TreasureKey.Commands.Create
{
    using MediatR;

    public class CreateTreasureKeyCommand : IRequest
    {
        public string Rarity { get; set; }

        public string ImageURL { get; set; }
    }
}
