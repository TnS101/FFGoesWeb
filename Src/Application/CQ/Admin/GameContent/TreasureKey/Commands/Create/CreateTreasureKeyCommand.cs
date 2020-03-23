namespace Application.CQ.Admin.TreasureKey.Commands.Create
{
    using MediatR;

    public class CreateTreasureKeyCommand : IRequest<string>
    {
        public string Rarity { get; set; }

        public string ImageURL { get; set; }
    }
}
