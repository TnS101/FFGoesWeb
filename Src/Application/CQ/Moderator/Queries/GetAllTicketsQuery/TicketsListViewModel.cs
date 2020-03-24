namespace Application.CQ.Moderator.Queries.GetAllTicketsQuery
{
    using System.Collections.Generic;

    public class TicketsListViewModel
    {
        public IEnumerable<TicketPartialViewModel> Tickets { get; set; }
    }
}
