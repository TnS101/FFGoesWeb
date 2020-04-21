namespace Application.CQ.Social.Messages.Commands.Create
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using Application.Common.StringProcessing.RegexFilters;
    using global::Common;
    using MediatR;

    public class SendMessageCommand : RegexFilter, IRequest<string>
    {
        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(200, ErrorMessage = GConst.LengthMessage, MinimumLength = 2)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        public string Content { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        [Required]
        public string RecieverName { get; set; }
    }
}
