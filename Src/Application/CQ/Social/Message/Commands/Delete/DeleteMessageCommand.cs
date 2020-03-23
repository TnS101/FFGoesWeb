namespace Application.CQ.Forum.Message.Commands.Delete
{
    using MediatR;

    public class DeleteMessageCommand : IRequest<string>
    {
        public string MessageId { get; set; }
    }
}
