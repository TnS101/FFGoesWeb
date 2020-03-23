namespace Application.CQ.Admin.Moderation.Feedback.Commands.Update
{
    using MediatR;

    public class AcceptFeedbackCommand : IRequest<string>
    {
        public string SenderId { get; set; }

        public string FeedbackId { get; set; }

        public int Stars { get; set; }
    }
}
