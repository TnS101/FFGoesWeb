namespace Application.CQ.Forum.Topic.Commands.Update
{
    using MediatR;

    public class EditTopicCommand : IRequest<string>
    {
        public string TopicId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
    }
}
