namespace Application.GameCQ.Item.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class LootItemCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }

        public int ItemId { get; set; }
    }
}
