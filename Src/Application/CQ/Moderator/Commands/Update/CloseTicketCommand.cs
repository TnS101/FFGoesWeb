﻿namespace Application.CQ.Moderator.Commands.Update
{
    using MediatR;

    public class CloseTicketCommand : IRequest<string>
    {
        public int TicketId { get; set; }

        public int Stars { get; set; }
    }
}
