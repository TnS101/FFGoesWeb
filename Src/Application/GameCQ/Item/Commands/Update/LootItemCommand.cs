namespace Application.GameCQ.Item.Commands.Update
{
    using MediatR;

    public class LootItemCommand : IRequest
    {
        public int ItemId { get; set; }

        public int UnitId { get; set; }
    }
}
