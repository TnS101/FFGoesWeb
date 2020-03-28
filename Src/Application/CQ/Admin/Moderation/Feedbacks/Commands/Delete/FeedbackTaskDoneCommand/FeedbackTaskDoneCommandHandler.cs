namespace Application.CQ.Admin.Moderation.Feedback.Commands.Delete.FeedbackTaskDoneCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class FeedbackTaskDoneCommandHandler : IRequestHandler<FeedbackTaskDoneCommand, string>
    {
        private readonly IFFDbContext context;

        public FeedbackTaskDoneCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(FeedbackTaskDoneCommand request, CancellationToken cancellationToken)
        {
            var feedbackTaskIsDone = await this.context.Feedbacks.FindAsync(request.FeedbackId);

            this.context.Feedbacks.Remove(feedbackTaskIsDone);

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.ToDoListRedirect;
        }
    }
}
