namespace Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;

    public class DeleteFeedbackCommandHandler : BaseHandler, IRequestHandler<DeleteFeedbackCommand, string>
    {
        public DeleteFeedbackCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            this.Context.Feedbacks.Remove(await this.Context.Feedbacks.FindAsync(request.FeedbackId));

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.AdminFeedbackCommandRedirect;
        }
    }
}
