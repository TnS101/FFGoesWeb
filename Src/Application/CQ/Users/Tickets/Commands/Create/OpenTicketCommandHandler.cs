namespace Application.CQ.Users.Tickets.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Moderation;
    using global::Common;
    using MediatR;

    public class OpenTicketCommandHandler : BaseHandler, IRequestHandler<OpenTicketCommand, string>
    {
        public OpenTicketCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(OpenTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
                Category = request.Category,
                AdditionalInformation = request.AdditionalInformation,
                UserId = request.UserId,
                SentOn = DateTime.UtcNow,
                Content = request.Content,
                Type = request.ContentType,
            };

            if (request.ContentType == "Topic")
            {
                var topic = await this.Context.Topics.FindAsync(request.ContentId);
                ticket.TopicId = topic.Id;
                ticket.ReportedUserId = topic.UserId;
            }
            else if (request.ContentType == "Comment")
            {
                var comment = await this.Context.Comments.FindAsync(request.ContentId);
                ticket.CommentId = comment.Id;
                ticket.ReportedUserId = comment.UserId;
            }
            else
            {
                var message = await this.Context.Messages.FindAsync(request.ContentId);
                ticket.MessageId = message.Id;
                ticket.ReportedUserId = message.UserId;
            }

            this.Context.Tickets.Add(ticket);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.OpenTicketRedirect);
        }
    }
}
