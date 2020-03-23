namespace Application.CQ.Forum.Topic.Commands.Create
{
    using MediatR;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;

    public class CreateTopicCommand : IRequest<string[]>
    {
        public ClaimsPrincipal User { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 5)]
        [RegularExpression(@"[A-Z][a-z]\w+")]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
