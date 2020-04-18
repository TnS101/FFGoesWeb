namespace Application.CQ.Social.Topics.Commands.Update
{
    using System.ComponentModel.DataAnnotations;
    using Application.Common.RegexFilters;
    using global::Common;
    using MediatR;

    public class EditTopicCommand : RegexFilter, IRequest<string>
    {
        public string TopicId { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(20, ErrorMessage = GConst.LengthMessage, MinimumLength = 5)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        [ContentFilter(GConst.ContentFilter, ErrorMessage = GConst.ContentMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        public string Category { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(200, ErrorMessage = GConst.LengthMessage, MinimumLength = 20)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        public string Content { get; set; }
    }
}
