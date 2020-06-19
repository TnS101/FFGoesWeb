namespace Application.GameCQ.LootBoxes.Commands.Delete
{
    using MediatR;

    public class OpenLootBoxCommand : IRequest<string>
    {
        public string Id { get; set; }

        public int Reward { get; set; }

        public string UserId { get; set; }
    }
}
