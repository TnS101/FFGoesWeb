namespace Application.CQ.Users.Tickets.Commands.Create
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using Application.Common.RegexFilters;
    using global::Common;
    using MediatR;

    public class OpenTicketCommand : RegexFilter, IRequest<string>
    {
        [Required]
        public string ContentId { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        [Required]
        public string Category { get; set; }

        [StringLength(60, ErrorMessage = GConst.LengthMessage, MinimumLength = 5)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        public string AdditionalInformation { get; set; }

        [Required]
        public string ContentType { get; set; }
    }
}
