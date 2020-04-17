namespace Application.CQ.Social.Messages.Queries
{
    using System.Collections.Generic;

    public class MessageListViewModel
    {
        public IEnumerable<MessageFullViewModel> Messages { get; set; }
    }
}
