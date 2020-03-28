namespace Application.CQ.Admin.Moderation.Feedbacks.Commands.Update
{
    using MediatR;

    public class AcceptFeedbackCommand : IRequest<string>
    {
        public int FeedbackId { get; set; }

        public int Stars { get; set; }
    }
}
