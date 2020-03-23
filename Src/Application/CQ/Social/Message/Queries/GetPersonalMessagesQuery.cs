namespace Application.CQ.Forum.Message.Queries
{
    using MediatR;
    using System.Security.Claims;

    public class GetPersonalMessagesQuery : IRequest<MessageListViewModel>
    {
        public ClaimsPrincipal Reciever { get; set; }

        public string SenderName { get; set; }
    }
}
