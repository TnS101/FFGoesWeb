namespace Application.CQ.Admin.Moderation.Feedbacks.Commands.Delete.DeleteFeedbackCommand
{
    using MediatR;

    public class DeleteFeedbackCommand : IRequest<string>
    {
        public int FeedbackId { get; set; }
    }
}
