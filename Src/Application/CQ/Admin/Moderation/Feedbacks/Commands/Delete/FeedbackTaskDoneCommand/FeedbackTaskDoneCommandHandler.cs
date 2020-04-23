namespace Application.CQ.Admin.Moderation.Feedback.Commands.Delete.FeedbackTaskDoneCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class FeedbackTaskDoneCommandHandler : BaseHandler, IRequestHandler<FeedbackTaskDoneCommand, string>
    {
        public FeedbackTaskDoneCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(FeedbackTaskDoneCommand request, CancellationToken cancellationToken)
        {
            var feedbackTaskIsDone = await this.Context.Feedbacks.FindAsync(request.FeedbackId);

            this.Context.Feedbacks.Remove(feedbackTaskIsDone);

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminToDoListRedirect;
        }
    }
}
