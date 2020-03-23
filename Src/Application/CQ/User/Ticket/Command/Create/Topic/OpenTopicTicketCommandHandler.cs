namespace Application.CQ.User.Ticket.Command.Topic
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class OpenTopicTicketCommandHandler : IRequestHandler<OpenTopicTicketCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OpenTopicTicketCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(OpenTopicTicketCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var topic = await this.context.Topics.FindAsync(request.TopicId);

            var ticket = new Domain.Entities.Moderation.Ticket
            {
                Category = request.Category,
                AdditionalInformation = request.AdditionalInformation,
                UserId = sender.Id,
                SentOn = DateTime.UtcNow,
                TopicId = request.TopicId,
                ReportedUserName = topic.User.UserName,
            };

            this.context.Tickets.Add(ticket);

            var topicId = ticket.TopicId;

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.OpenCommentTicketRedirect, topicId);
        }
    }
}
