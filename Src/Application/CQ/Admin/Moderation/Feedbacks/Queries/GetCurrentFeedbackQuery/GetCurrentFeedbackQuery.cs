﻿namespace Application.CQ.Admin.Moderation.Feedback.Queries.GetCurrentFeedbackQuery
{
    using MediatR;

    public class GetCurrentFeedbackQuery : IRequest<FeedbackFullViewModel>
    {
        public int FeedbackId { get; set; }
    }
}
