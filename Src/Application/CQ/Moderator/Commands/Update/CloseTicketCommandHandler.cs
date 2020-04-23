namespace Application.CQ.Moderator.Commands.Update
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Moderation;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CloseTicketCommandHandler : BaseHandler, IRequestHandler<CloseTicketCommand, string>
    {
        public CloseTicketCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(CloseTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await this.Context.Tickets.FindAsync(request.TicketId);

            var sender = this.Context.AppUsers.FirstOrDefault(s => s.UserName == ticket.ReportedUserId);

            var reportedUser = await this.Context.AppUsers.FindAsync(ticket.ReportedUserId);

            await this.DeleteAction(ticket);

            this.Punishment(reportedUser);

            this.SenderReward(sender, request);

            await this.Context.SaveChangesAsync(cancellationToken);

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
                var comment = await this.Context.Comments.FindAsync(ticket.CommentId);

                var likesToRemove = await this.Context.Likes.Where(l => l.CommentId == comment.Id).ToListAsync();

                this.Context.Likes.RemoveRange(likesToRemove);

                comment.IsRemoved = true;

                comment.Content = string.Format(GConst.RemovedContentMessage, "comment", ticket.Category);

                this.Context.Comments.Update(comment);
            }
        }

        private async Task DeleteTopic(Ticket ticket)
        {
            if (ticket.Type == GConst.CommentType)
            {
                var topic = await this.Context.Topics.FindAsync(ticket.TopicId);

                var comments = this.Context.Comments.FirstOrDefault(c => c.TopicId == topic.Id);

                var likesToRemove = await this.Context.Likes.Where(l => l.CommentId == topic.Id).ToListAsync();

                this.Context.Likes.RemoveRange(likesToRemove);

                topic.IsRemoved = true;

                topic.Content = string.Format(GConst.RemovedContentMessage, "topic", ticket.Category);

                this.Context.Comments.RemoveRange(comments);

                this.Context.Topics.Update(topic);
            }
        }

        private async Task DeleteMessage(Ticket ticket)
        {
            if (ticket.MessageId == GConst.CommentType)
            {
                var message = await this.Context.Messages.FindAsync(ticket.MessageId);

                message.IsRemoved = true;

                message.Content = string.Format(GConst.RemovedContentMessage, "message", ticket.Category);

                this.Context.Messages.Update(message);
            }
        }

        private void Punishment(AppUser reportedUser)
        {
            if (reportedUser.Warnings == 2)
            {
                reportedUser.Notifications.Add(new Notification
                {
                    Content = string.Format(GConst.WarningMessage, reportedUser.UserName, reportedUser.Warnings),
                    UserId = reportedUser.Id,
                    Type = GConst.WarningType,
                });
            }

            if (reportedUser.Warnings > 2)
            {
                reportedUser.Notifications.Add(new Notification
                {
                    Content = string.Format(GConst.PenaltyType, reportedUser.UserName, 1),
                    UserId = reportedUser.Id,
                    Type = GConst.PenaltyType,
                });
            }

            if (reportedUser.Warnings > 3)
            {
                reportedUser.Notifications.Add(new Notification
                {
                    Content = string.Format(GConst.PenaltyType, reportedUser.UserName, 3),
                    UserId = reportedUser.Id,
                    Type = GConst.PenaltyType,
                });
            }
        }

        private void SenderReward(AppUser sender, CloseTicketCommand request)
        {
            this.Context.Notifications.Add(new Notification
            {
                ApplicationSection = GConst.Forum,
                Type = GConst.RewardType,
                Content = string.Format(GConst.ClosedTicket, sender.UserName, request.Stars),
                UserId = sender.Id,
            });

            sender.Stars += request.Stars;

            this.Context.AppUsers.Update(sender);
        }
    }
}
