namespace Application.GameCQ.TreasureKey.Commands.Update
{
    using MediatR;

    public class LootTreasureKeyCommand : IRequest
    {
        public int UnitId { get; set; }
    }
}
