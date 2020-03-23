namespace Application.CQ.Forum.Message.Commands.Create
{
    using MediatR;
    using System.Security.Claims;

    public class SendMessageCommand : IRequest<string>
    {
        public string Content { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        public string RecieverName { get; set; }
    }
}
