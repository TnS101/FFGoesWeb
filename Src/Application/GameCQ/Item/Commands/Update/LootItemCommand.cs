namespace Application.GameCQ.Item.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class LootItemCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }

        public int ItemId { get; set; }
    }
}
