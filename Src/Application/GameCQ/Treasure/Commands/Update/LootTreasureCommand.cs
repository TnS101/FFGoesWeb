namespace Application.GameCQ.Treasure.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class LootTreasureCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }
    }
}
