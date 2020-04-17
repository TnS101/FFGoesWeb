namespace Application.CQ.Social.Messages.Commands.Create
{
    using MediatR;

    public class DeleteMessageCommand : IRequest<string>
    {
        public string MessageId { get; set; }
    }
}
