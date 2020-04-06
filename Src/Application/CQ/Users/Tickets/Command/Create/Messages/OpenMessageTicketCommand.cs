﻿namespace Application.CQ.Users.Tickets.Command.Messages
{
    using System.Security.Claims;
    using MediatR;

    public class OpenMessageTicketCommand : IRequest<string>
    {
        public string MessageId { get; set; }

        public ClaimsPrincipal Sender { get; set; }

        public string Category { get; set; }

        public string AdditionalInformation { get; set; }
    }
}