namespace Application.CQ.Admin.Moderation.Feedback.Commands.Delete
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, string>
    {
        private readonly IFFDbContext context;
        public DeleteFeedbackCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            this.context.Feedbacks.Remove(await this.context.Feedbacks.FindAsync(request.FeedbackId)); //might be a DeadLock

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.FeedbackRedirect;
        }
    }
}
