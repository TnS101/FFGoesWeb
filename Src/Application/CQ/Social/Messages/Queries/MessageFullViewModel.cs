namespace Application.CQ.Social.Messages.Queries
{
    using System;

    public class MessageFullViewModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }
    }
}
