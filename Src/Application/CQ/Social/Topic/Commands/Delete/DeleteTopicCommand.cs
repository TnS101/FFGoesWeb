namespace Application.CQ.Forum.Topic.Commands.Delete
{
    using MediatR;
    using System.Security.Claims;

    public class DeleteTopicCommand : IRequest<string>
    {
        public string TopicId { get; set; }
    }
}
