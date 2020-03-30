namespace Application.GameCQ.Items.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class DiscardItemCommand : IRequest<string>
    {
        public ClaimsPrincipal User { get; set; }

        public string ItemId { get; set; }

        public string Slot { get; set; }
    }
}
