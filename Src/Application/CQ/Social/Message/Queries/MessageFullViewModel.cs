namespace Application.CQ.Forum.Message.Queries
{
    using System;

    public class MessageFullViewModel
    {
        public string MessageId { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }
    }
}
