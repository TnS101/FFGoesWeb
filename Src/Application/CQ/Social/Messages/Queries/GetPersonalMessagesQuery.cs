namespace Application.CQ.Social.Messages.Queries
{
    using MediatR;

    public class GetPersonalMessagesQuery : IRequest<MessageListViewModel>
    {
        public string UserId { get; set; }

        public string SenderId { get; set; }
    }
}
