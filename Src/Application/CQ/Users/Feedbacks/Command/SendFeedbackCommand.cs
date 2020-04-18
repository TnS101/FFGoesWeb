namespace Application.CQ.Users.Feedbacks.Command
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using Application.Common.RegexFilters;
    using global::Common;
    using MediatR;

    public class SendFeedbackCommand : RegexFilter, IRequest<string>
    {
        public ClaimsPrincipal Sender { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(100, ErrorMessage = GConst.LengthMessage, MinimumLength = 10)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        public string Content { get; set; }

        public int Rate { get; set; }
    }
}
