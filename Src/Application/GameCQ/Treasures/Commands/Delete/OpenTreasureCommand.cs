namespace Application.GameCQ.Treasures.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class OpenTreasureCommand : IRequest<string>
    {
        public int Id { get; set; }

        public int Reward { get; set; }

        public string Rarity { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
