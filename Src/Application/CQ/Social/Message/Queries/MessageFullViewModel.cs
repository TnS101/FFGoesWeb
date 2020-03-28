namespace Application.CQ.Social.Message.Queries
{
    using System;

    public class MessageFullViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public DateTime SentOn { get; set; }
    }
}
