namespace Application.CQ.Users.Tickets.Command.Topics
{
    using System.Security.Claims;
    using MediatR;

    public class OpenTopicTicketCommand : IRequest<string>
    {
        public string TopicId { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        public string Category { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
