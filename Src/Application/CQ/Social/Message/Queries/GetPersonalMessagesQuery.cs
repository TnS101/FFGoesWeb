namespace Application.CQ.Forum.Message.Queries
{
    using System.Security.Claims;
    using MediatR;

    public class GetPersonalMessagesQuery : IRequest<MessageListViewModel>
    {
        public ClaimsPrincipal Reciever { get; set; }

        public string SenderName { get; set; }
    }
}
