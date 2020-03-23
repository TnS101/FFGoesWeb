namespace Application.GameCQ.Treasure.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class LootTreasureCommand : IRequest<string>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
