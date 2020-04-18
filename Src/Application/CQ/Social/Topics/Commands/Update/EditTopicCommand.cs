namespace Application.CQ.Social.Topics.Commands.Update
{
    using MediatR;

    public class EditTopicCommand : IRequest<string>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
    }
}
