namespace Application.CQ.Moderator.Queries.GetCurrentTicketQuery
{
    using MediatR;

    public class GetCurrentTicketQuery : IRequest<TicketFullViewModel>
    {
        public string TicketId { get; set; }
    }
}
