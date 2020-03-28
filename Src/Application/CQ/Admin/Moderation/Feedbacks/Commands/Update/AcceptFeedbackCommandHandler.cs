namespace Application.CQ.Admin.Moderation.Feedbacks.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class AcceptFeedbackCommandHandler : IRequestHandler<AcceptFeedbackCommand, string>
    {
        private readonly IFFDbContext context;

        public AcceptFeedbackCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(AcceptFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedBack = await this.context.Feedbacks.FindAsync(request.FeedbackId);

            var user = await this.context.AppUsers.FindAsync(feedBack.UserId);

            user.Stars += request.Stars;

            feedBack.IsAccepted = true;

            this.context.Feedbacks.Update(feedBack);

            this.context.AppUsers.Update(user);

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AcceptedFeedback, user.UserName, request.Stars);
        }
    }
}
