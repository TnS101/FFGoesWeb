namespace Application.CQ.Users.Tickets.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Moderation;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class OpenTicketCommandHandler : IRequestHandler<OpenTicketCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OpenTicketCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(OpenTicketCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var ticket = new Ticket
            {
                Category = request.Category,
                AdditionalInformation = request.AdditionalInformation,
                UserId = sender.Id,
                SentOn = DateTime.UtcNow,
            };

            if (request.ContentType == "Topic")
            {
                var topic = await this.context.Topics.FindAsync(request.ContentId);
                ticket.TopicId = topic.Id;
                ticket.ReportedUserId = topic.UserId;
                ticket.Type = "Topic";
            }
            else if (request.ContentType == "Comment")
            {
                var comment = await this.context.Comments.FindAsync(request.ContentId);
                ticket.CommentId = comment.Id;
                ticket.ReportedUserId = comment.UserId;
                ticket.Type = "Comment";
            }
            else
            {
                var message = await this.context.Messages.FindAsync(request.ContentId);
                ticket.MessageId = message.Id;
                ticket.ReportedUserId = message.UserId;
                ticket.Type = "Message";
            }

            this.context.Tickets.Add(ticket);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.OpenCommentTicketRedirect);
        }
    }
}
