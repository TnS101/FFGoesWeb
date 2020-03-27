namespace Application.CQ.Moderator.Commands.Delete
{
    using MediatR;

    public class DeleteTicketCommand : IRequest<string>
    {
        public int TicketId { get; set; }
    }
}
