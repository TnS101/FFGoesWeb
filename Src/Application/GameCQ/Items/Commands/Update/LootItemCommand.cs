namespace Application.GameCQ.Items.Commands.Update
{
    using System.Security.Claims;
    using Domain.Entities.Game.Units;
    using MediatR;

    public class LootItemCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }

        public string ZoneName { get; set; }

        public int MonsterId { get; set; }
    }
}
