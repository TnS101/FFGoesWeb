namespace Application.GameCQ.Items.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class LootItemCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }

        public string ItemId { get; set; }
    }
}
