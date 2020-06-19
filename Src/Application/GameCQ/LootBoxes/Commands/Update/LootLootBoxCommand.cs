namespace Application.GameCQ.LootBoxes.Commands.Update
{
    using MediatR;

    public class LootLootBoxCommand : IRequest<string>
    {
        public string UserId { get; set; }
    }
}
