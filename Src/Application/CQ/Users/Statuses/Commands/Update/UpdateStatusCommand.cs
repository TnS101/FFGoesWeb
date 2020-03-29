﻿namespace Application.CQ.Users.Statuses.Commands.Update
{
    using System.Security.Claims;
    using MediatR;

    public class UpdateStatusCommand : IRequest<string>
    {
        public ClaimsPrincipal User { get; set; }

        public string StatusName { get; set; }
    }
}