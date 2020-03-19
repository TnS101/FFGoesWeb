namespace Application.GameCQ.Item.Commands.Delete
{
    using MediatR;
    using System.Security.Claims;

    public class DiscardItemCommand : IRequest
    {
        public ClaimsPrincipal User { get; set; }

        public string ItemId { get; set; }
    }
}
