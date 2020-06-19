namespace Application.GameCQ.LootKeys.Commands.Update
{
    using MediatR;

    public class LootLootKeyCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
