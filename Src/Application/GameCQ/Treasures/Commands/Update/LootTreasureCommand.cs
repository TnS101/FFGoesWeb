namespace Application.GameCQ.Treasures.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class LootTreasureCommand : IRequest<string>
    {
        public string UserId { get; set; }
    }
}
