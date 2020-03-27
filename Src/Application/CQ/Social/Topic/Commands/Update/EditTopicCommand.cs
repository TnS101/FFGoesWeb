namespace Application.CQ.Forum.Topic.Commands.Update
{
    using System;
    using MediatR;

    public class EditTopicCommand : IRequest<string>
    {
        public int TopicId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
    }
}
