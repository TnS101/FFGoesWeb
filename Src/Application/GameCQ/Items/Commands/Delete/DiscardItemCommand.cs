namespace Application.GameCQ.Item.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class DiscardItemCommand : IRequest<string>
    {
        public ClaimsPrincipal User { get; set; }

        public int ItemId { get; set; }
    }
}
