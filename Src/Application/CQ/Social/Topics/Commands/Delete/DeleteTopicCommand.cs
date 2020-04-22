namespace Application.CQ.Social.Topics.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class DeleteTopicCommand : IRequest<string>
    {
        public string TopicId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
