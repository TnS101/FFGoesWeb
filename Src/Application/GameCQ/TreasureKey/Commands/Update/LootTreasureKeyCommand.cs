namespace Application.GameCQ.TreasureKey.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class LootTreasureKeyCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }
    }
}
