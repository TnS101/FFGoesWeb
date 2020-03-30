namespace Application.CQ.Social.Message.Commands.Create
{
    using MediatR;

    public class DeleteMessageCommand : IRequest<string>
    {
        public string MessageId { get; set; }
    }
}
