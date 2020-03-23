namespace Application.CQ.Moderator.Commands.Delete
{
    using MediatR;

    public class DeleteTicketCommand : IRequest<string>
    {
        public string TicketId { get; set; }
    }
}
