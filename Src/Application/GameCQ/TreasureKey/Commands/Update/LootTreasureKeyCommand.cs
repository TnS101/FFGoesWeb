namespace Application.GameCQ.TreasureKey.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class LootTreasureKeyCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }
    }
}
