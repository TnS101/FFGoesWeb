namespace Application.GameCQ.Treasure.Commands.Update
{
    using MediatR;

    public class LootTreasureCommand : IRequest
    {
        public int UnitId { get; set; }
    }
}
