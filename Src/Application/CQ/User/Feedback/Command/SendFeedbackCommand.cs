﻿namespace Application.CQ.User.Feedback.Command
{
    using System;
    using System.Security.Claims;
    using MediatR;

    public class SendFeedbackCommand : IRequest<string[]>
    {
        public ClaimsPrincipal Sender { get; set; }

        public string Content { get; set; }
    }
}
