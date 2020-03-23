namespace Application.CQ.Admin.Moderation.Feedback.Commands.Delete
{
    using MediatR;

    public class DeleteFeedbackCommand : IRequest<string>
    {
        public string FeedbackId { get; set; }
    }
}
