namespace Application.CQ.Social.Topics.Commands.Create
{
    using System.ComponentModel.DataAnnotations;
    using Application.Common.StringProcessing.RegexFilters;
    using global::Common;
    using MediatR;

    public class CreateTopicCommand : RegexFilter, IRequest
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(50, ErrorMessage = GConst.LengthMessage, MinimumLength = 5)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        public string Category { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(200, ErrorMessage = GConst.LengthMessage, MinimumLength = 6)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        public string Content { get; set; }

    }
}
