namespace Application.CQ.Moderator.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Moderation;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CloseTicketCommandHandler : IRequestHandler<CloseTicketCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public CloseTicketCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(CloseTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await this.context.Tickets.FindAsync(request.TicketId);

            var sender = this.context.AppUsers.FirstOrDefault(s => s.UserName == ticket.ReportedUserName);

            var reportedUser = await this.userManager.FindByNameAsync(ticket.ReportedUserName);

            await this.DeleteAction(ticket);

            this.Punishment(reportedUser);

            this.SenderReward(sender, request);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.TicketCommandRedirect;
        }

        private async Task DeleteAction(Ticket ticket)
        {
            await this.DeleteComment(ticket);

            await this.DeleteTopic(ticket);

            await this.DeleteMessage(ticket);
        }

        private async Task DeleteComment(Ticket ticket)
        {
            if (ticket.Type == GConst.CommentType)
            {
                var comment = await this.context.Comments.FindAsync(ticket.CommentId);

                comment.Likes = 0;

                comment.IsRemoved = true;

                comment.Content = string.Format(GConst.RemovedContentMessage, "comment", ticket.Category);

                this.context.Comments.Update(comment);
            }
        }

        private async Task DeleteTopic(Ticket ticket)
        {
            if (ticket.Type == GConst.CommentType)
            {
                var topic = await this.context.Topics.FindAsync(ticket.TopicId);

                var comments = this.context.Comments.FirstOrDefault(c => c.TopicId == topic.Id);

                topic.Likes = 0;

                topic.IsRemoved = true;

                topic.Content = string.Format(GConst.RemovedContentMessage, "topic", ticket.Category);

                this.context.Comments.RemoveRange(comments);

                this.context.Topics.Update(topic);
            }
        }

        private async Task DeleteMessage(Ticket ticket)
        {
            if (ticket.MessageId == GConst.CommentType)
            {
                var message = await this.context.Messages.FindAsync(ticket.MessageId);

                message.IsRemoved = true;

                message.Content = string.Format(GConst.RemovedContentMessage, "message", ticket.Category);

                this.context.Messages.Update(message);
            }
        }

        private void Punishment(AppUser reportedUser)
        {
            if (reportedUser.Warnings == 2)
            {
                reportedUser.Notifications.Add(new Domain.Entities.Common.Social.Notification
                {
                    Content = string.Format(GConst.WarningMessage, reportedUser.UserName, reportedUser.Warnings),
                    UserId = reportedUser.Id,
                    Type = GConst.WarningType,
                });
            }

            if (reportedUser.Warnings > 2)
            {
                reportedUser.Notifications.Add(new Domain.Entities.Common.Social.Notification
                {
                    Content = string.Format(GConst.PenaltyType, reportedUser.UserName, 1),
                    UserId = reportedUser.Id,
                    Type = GConst.PenaltyType,
                });
            }

            if (reportedUser.Warnings > 3)
            {
                reportedUser.Notifications.Add(new Domain.Entities.Common.Social.Notification
                {
                    Content = string.Format(GConst.PenaltyType, reportedUser.UserName, 3),
                    UserId = reportedUser.Id,
                    Type = GConst.PenaltyType,
                });
            }
        }

        private void SenderReward(AppUser sender, CloseTicketCommand request)
        {
            this.context.Notifications.Add(new Notification
            {
                ApplicationSection = GConst.Forum,
                Type = GConst.RewardType,
                Content = string.Format(GConst.ClosedTicket, sender.UserName, request.Stars),
                UserId = sender.Id,
            });

            sender.Stars += request.Stars;

            this.context.AppUsers.Update(sender);
        }
    }
}
