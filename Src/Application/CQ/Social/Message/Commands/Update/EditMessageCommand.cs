namespace Application.CQ.Social.Message.Commands.Create
{
    using MediatR;

    public class EditMessageCommand : IRequest<string>
    {
        public string MessageId { get; set; }

        public string Content { get; set; }
    }
}
