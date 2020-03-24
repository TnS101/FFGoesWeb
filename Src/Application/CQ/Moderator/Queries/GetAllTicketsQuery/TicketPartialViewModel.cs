namespace Application.CQ.Moderator.Queries.GetAllTicketsQuery
{
    using System;

    public class TicketPartialViewModel
    {
        public string Id { get; set; }

        public string Category { get; set; }

        public DateTime SentOn { get; set; }
    }
}
