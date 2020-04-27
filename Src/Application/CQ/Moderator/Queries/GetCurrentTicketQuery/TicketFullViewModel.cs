namespace Application.CQ.Moderator.Queries.GetCurrentTicketQuery
{
    using System;

    public class TicketFullViewModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public string Category { get; set; }

        public string ReportedUserName { get; set; }

        public string AdditionalInformation { get; set; }

        public DateTime SentOn { get; set; }
    }
}
