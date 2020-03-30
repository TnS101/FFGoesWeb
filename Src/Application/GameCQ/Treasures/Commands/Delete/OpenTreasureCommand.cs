﻿namespace Application.GameCQ.Treasures.Commands.Delete
{
    using System.Security.Claims;
    using MediatR;

    public class OpenTreasureCommand : IRequest<string>
    {
        public string Id { get; set; }

        public int Reward { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
