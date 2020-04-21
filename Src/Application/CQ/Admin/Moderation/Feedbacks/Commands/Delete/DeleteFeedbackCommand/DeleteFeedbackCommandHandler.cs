namespace Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteFeedbackCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            this.context.Feedbacks.Remove(await this.context.Feedbacks.FindAsync(request.FeedbackId));

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.AdminFeedbackCommandRedirect;
        }
    }
}
