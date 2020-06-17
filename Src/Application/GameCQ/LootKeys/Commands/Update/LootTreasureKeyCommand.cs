namespace Application.GameCQ.TreasureKeys.Commands.Update
{
    using MediatR;

    public class LootTreasureKeyCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
