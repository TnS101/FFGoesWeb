namespace Application.CQ.Admin.Moderation.Feedback.Commands.Update
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Common;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class AcceptFeedbackCommandHandler : IRequestHandler<AcceptFeedbackCommand, string>
    {
        private readonly IFFDbContext context;

        public AcceptFeedbackCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(AcceptFeedbackCommand request, CancellationToken cancellationToken)
        {
            var user = await this.context.AppUsers.FindAsync(request.SenderId);

            var feedBack = user.Feedbacks.FirstOrDefault(f => f.Id == request.FeedbackId);

            user.Stars += request.Stars;

            feedBack.IsAccepted = true;

            this.context.Feedbacks.Update(feedBack);

            this.context.AppUsers.Update(user);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AcceptedFeedback, user.UserName, request.Stars);
        }
    }
}
