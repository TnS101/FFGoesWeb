namespace Application.CQ.Forum.Topic.Commands.Create
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using MediatR;

    public class CreateTopicCommand : IRequest<string[]>
    {
        public ClaimsPrincipal User { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
    }
}
