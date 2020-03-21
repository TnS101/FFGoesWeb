namespace Application.GameCQ.Treasure.Commands.Delete
{
    using MediatR;
    using System.Security.Claims;

    public class OpenTreasureCommand : IRequest<string>
    {
        public int Id { get; set; }

        public int Reward { get; set; }

        public string Rarity { get; set; }

        public ClaimsPrincipal User { get; set; } 
    }
}
