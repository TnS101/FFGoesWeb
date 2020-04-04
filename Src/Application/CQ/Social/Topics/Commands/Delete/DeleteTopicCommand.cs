namespace Application.CQ.Forum.Topic.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class DeleteTopicCommand : IRequest<string>
    {
        public string TopicId { get; set; }
    }
}
