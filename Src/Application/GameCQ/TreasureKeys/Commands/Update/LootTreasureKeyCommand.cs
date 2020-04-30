namespace Application.GameCQ.TreasureKeys.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class LootTreasureKeyCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
