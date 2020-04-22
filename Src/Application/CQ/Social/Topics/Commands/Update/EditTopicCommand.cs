namespace Application.CQ.Social.Topics.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class EditTopicCommand : IRequest<string>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
