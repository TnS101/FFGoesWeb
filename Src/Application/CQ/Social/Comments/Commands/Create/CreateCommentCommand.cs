namespace Application.CQ.Social.Comments.Commands.Create
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using global::Common;
    using MediatR;

    public class CreateCommentCommand : IRequest<string>
    {
        [Required(ErrorMessage = GConst.RequiredMessage)]
        [StringLength(200, ErrorMessage = GConst.LengthMessage, MinimumLength = 5)]
        [RegularExpression(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        public string Content { get; set; }

        [Required]
        public string TopicId { get; set; }

        public string UserId { get; set; }
    }

    public class SwearFilter : RegularExpressionAttribute
    {
        public SwearFilter(string pattern)
            : base(pattern) { }
    }
}
