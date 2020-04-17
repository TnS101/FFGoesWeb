namespace Application.CQ.Social.Messages.Commands.Create
{
    using MediatR;

    public class EditMessageCommand : IRequest<string>
    {
        public string MessageId { get; set; }

        public string Content { get; set; }
    }
}
