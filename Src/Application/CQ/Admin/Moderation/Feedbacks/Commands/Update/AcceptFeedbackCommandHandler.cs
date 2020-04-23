namespace Application.CQ.Admin.Moderation.Feedbacks.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Social;
    using global::Common;
    using MediatR;

    public class AcceptFeedbackCommandHandler : BaseHandler, IRequestHandler<AcceptFeedbackCommand, string>
    {
        public AcceptFeedbackCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(AcceptFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedBack = await this.Context.Feedbacks.FindAsync(request.FeedbackId);

            var user = await this.Context.AppUsers.FindAsync(feedBack.UserId);

            if (request.Stars == 0)
            {
                request.Stars = 1;
            }

            user.Stars += request.Stars;

            feedBack.IsAccepted = true;
            feedBack.Stars = request.Stars;

            this.Context.Notifications.Add(new Notification
            {
                ApplicationSection = "Game",
                Type = "Reward",
                UserId = user.Id,
                Content = string.Format(GConst.AcceptedFeedback, user.UserName, request.Stars),
                RecievedOn = DateTime.UtcNow,
            });

            this.Context.Feedbacks.Update(feedBack);

            this.Context.AppUsers.Update(user);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminFeedbackCommandRedirect;
        }
    }
}
