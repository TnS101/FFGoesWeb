namespace Application.CQ.User.Ticket.Command.Message
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class OpenMessageTicketCommandHandler : IRequestHandler<OpenMessageTicketCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OpenMessageTicketCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(OpenMessageTicketCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var message = await this.context.Messages.FindAsync(request.MessageId);

            var ticket = new Domain.Entities.Moderation.Ticket
            {
                Category = request.Category,
                AdditionalInformation = request.AdditionalInformation,
                UserId = sender.Id,
                SentOn = DateTime.UtcNow,
                MessageId = request.MessageId,
                ReportedUserName = message.User.UserName,
            };

            this.context.Tickets.Add(ticket);

            var reportedUserName = ticket.Message.SenderName;

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.OpenMessageTicketRedirect, reportedUserName);
        }
    }
}
