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
        public string Title { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        public string Category { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        public string Content { get; set; }
    }
}
