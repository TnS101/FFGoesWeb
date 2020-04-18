namespace Application.CQ.Users.Feedbacks.Command
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

    public class SendFeedbackCommandHandler : IRequestHandler<SendFeedbackCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public SendFeedbackCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(SendFeedbackCommand request, CancellationToken cancellationToken)
        {
            var sender = await this.userManager.GetUserAsync(request.Sender);

            if (sender.LastFeedbackSentOn != null)
            {
                var days = (DateTime.UtcNow - sender.LastFeedbackSentOn.Value).Days;

                if (days <= 1)
                {
                    return GConst.ErrorRedirect;
                }
                else
                {
                    sender.LastFeedbackSentOn = DateTime.UtcNow;

                    this.context.Feedbacks.Add(new Feedback
                    {
                        Content = request.Content,
                        IsAccepted = false,
                        SentOn = DateTime.UtcNow,
                        Stars = 0,
                        UserId = sender.Id,
                        Rate = request.Rate,
                    });

                    this.context.AppUsers.Update(sender);

                    await this.context.SaveChangesAsync(cancellationToken);

                    return GConst.SuccesfulFeedbackRedirect;
                }
            }
            else
            {
                sender.LastFeedbackSentOn = DateTime.UtcNow;

                this.context.Feedbacks.Add(new Feedback
                {
                    Content = request.Content,
                    IsAccepted = false,
                    SentOn = DateTime.UtcNow,
                    Stars = 0,
                    UserId = sender.Id,
                    Rate = request.Rate,
                });

                this.context.AppUsers.Update(sender);

                await this.context.SaveChangesAsync(cancellationToken);

                return GConst.SuccesfulFeedbackRedirect;
            }
        }
    }
}
