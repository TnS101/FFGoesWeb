namespace Application.CQ.User.Ticket.Command.Comment
{
    using System.Security.Claims;
    using MediatR;

    public class OpenCommentTicketCommand : IRequest<string>
    {
        public string CommentId { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        public string Category { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
