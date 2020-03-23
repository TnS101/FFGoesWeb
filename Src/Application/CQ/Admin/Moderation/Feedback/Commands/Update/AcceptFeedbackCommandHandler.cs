using Domain.Entities.Common;
using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQ.Admin.Moderation.Feedback.Commands.Update
{
    public class AcceptFeedbackCommandHandler : IRequestHandler<AcceptFeedbackCommand, string>
    {
        private readonly IFFDbContext context;
        public AcceptFeedbackCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(AcceptFeedbackCommand request, CancellationToken cancellationToken)
        {
            var user = await this.context.Users.FindAsync(request.SenderId);

            var feedBack = user.Feedbacks.FirstOrDefault(f => f.Id == request.FeedbackId);

            user.Stars += request.Stars;

            feedBack.IsAccepted = true;

            this.context.Feedbacks.Update(feedBack);

            this.context.Users.Update(user);

            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
