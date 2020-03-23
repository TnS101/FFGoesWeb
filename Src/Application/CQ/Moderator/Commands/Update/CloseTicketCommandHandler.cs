namespace Application.CQ.Moderator.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
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

            if (reportedUser.Warnings == 2)
            {
                reportedUser.Notifications.Add(new Domain.Entities.Common.Social.Notification
                {
                    CauserName = GConst.ModeratorArea,
                    Content = string.Format(GConst.WarningMessage, reportedUser.UserName, reportedUser.Warnings),
                    UserId = reportedUser.Id,
                    Type = GConst.WarningType,
                });
            }

            if (reportedUser.Warnings > 2)
            {
                reportedUser.Notifications.Add(new Domain.Entities.Common.Social.Notification
                {
                    CauserName = GConst.ModeratorArea,
                    Content = string.Format(GConst.PenaltyType, reportedUser.UserName, 1),
                    UserId = reportedUser.Id,
                    Type = GConst.PenaltyType,
                });
            }

            if (reportedUser.Warnings > 3)
            {
                reportedUser.Notifications.Add(new Domain.Entities.Common.Social.Notification
                {
                    CauserName = GConst.ModeratorArea,
                    Content = string.Format(GConst.PenaltyType, reportedUser.UserName, 3),
                    UserId = reportedUser.Id,
                    Type = GConst.PenaltyType,
                });
            }

            sender.Stars += request.Stars;

            this.context.AppUsers.Update(sender);

            return GConst.TicketCommandRedirect;
        }
    }
}
