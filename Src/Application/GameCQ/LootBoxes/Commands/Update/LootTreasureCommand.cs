namespace Application.GameCQ.LootBoxes.Commands.Update
{
    using MediatR;

    public class LootTreasureCommand : IRequest<string>
    {
        public string UserId { get; set; }
    }
}
