namespace Application.CQ.Users.Tickets.Commands.Create
{
    using System.Security.Claims;
    using MediatR;

    public class OpenTicketCommand : IRequest<string>
    {
        public string ContentId { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        public string Category { get; set; }

        public string AdditionalInformation { get; set; }

        public string ContentType { get; set; }
    }
}
