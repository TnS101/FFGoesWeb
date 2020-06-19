namespace Application.GameCQ.LootBoxes.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class OpenTreasureCommand : IRequest<string>
    {
        public string Id { get; set; }

        public int Reward { get; set; }

        public string UserId { get; set; }
    }
}
