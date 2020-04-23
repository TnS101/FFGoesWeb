namespace Application.CQ.Users.Feedbacks.Command
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Moderation;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class SendFeedbackCommandHandler : UserHandler, IRequestHandler<SendFeedbackCommand, string>
    {
        public SendFeedbackCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(SendFeedbackCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.UserManager.GetUserAsync(request.Sender);

            if (sender.LastFeedbackSentOn != null)
            {
                var days = (DateTime.UtcNow - sender.LastFeedbackSentOn.Value).Days;

                if (days <= 1)
                {
                    return GConst.ErrorRedirect;
                }
                else
                {
                    return await this.SendFeedback(sender, request, cancellationToken);
                }
            }
            else
            {
                return await this.SendFeedback(sender, request, cancellationToken);
            }
        }

        private async Task<string> SendFeedback(AppUser sender, SendFeedbackCommand request, CancellationToken cancellationToken)
        {
            sender.LastFeedbackSentOn = DateTime.UtcNow;

            this.Context.Feedbacks.Add(new Feedback
            {
                Content = request.Content,
                IsAccepted = false,
                SentOn = DateTime.UtcNow,
                Stars = 0,
                UserId = sender.Id,
                Rate = request.Rate,
            });

            this.Context.AppUsers.Update(sender);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.SuccesfulFeedbackRedirect;
        }
    }
}
