namespace Application.CQ.Forum.Message.Commands.Create
{
    using System.Security.Claims;
    using MediatR;

    public class SendMessageCommand : IRequest<string>
    {
        public string Content { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        public string RecieverName { get; set; }
    }
}
