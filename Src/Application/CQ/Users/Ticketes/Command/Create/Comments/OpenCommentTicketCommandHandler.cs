namespace Application.CQ.Users.Tickets.Command.Comments
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class OpenCommentTicketCommandHandler : IRequestHandler<OpenCommentTicketCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OpenCommentTicketCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(OpenCommentTicketCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            var comment = await this.context.Comments.FindAsync(request.CommentId);

            var ticket = new Domain.Entities.Moderation.Ticket
            {
                Category = request.Category,
                AdditionalInformation = request.AdditionalInformation,
                UserId = sender.Id,
                SentOn = DateTime.UtcNow,
                CommentId = request.CommentId,
                ReportedUserName = comment.User.UserName,
                Type = GConst.CommentType,
            };

            this.context.Tickets.Add(ticket);

            var topicId = ticket.Comment.TopicId;

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.OpenCommentTicketRedirect, topicId);
        }
    }
}
