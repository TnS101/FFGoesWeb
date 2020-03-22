namespace Application.CQ.Forum.Message.Queries
{
    using System.Collections.Generic;

    public class MessageListViewModel
    {
        public IEnumerable<MessageFullViewModel> Messages { get; set; }
    }
}
