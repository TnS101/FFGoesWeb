﻿namespace Application.CQ.Admin.Moderation.Feedback.Commands.Delete.FeedbackTaskDoneCommand
{
    using MediatR;

    public class FeedbackTaskDoneCommand : IRequest<string>
    {
        public string FeedbackId { get; set; }
    }
}
