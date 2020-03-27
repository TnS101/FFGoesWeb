namespace Application.CQ.Moderator.Queries.GetCurrentTicketQuery
{
    using MediatR;

    public class GetCurrentTicketQuery : IRequest<TicketFullViewModel>
    {
        public int TicketId { get; set; }
    }
}
