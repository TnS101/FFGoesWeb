﻿namespace Application.GameCQ.Treasure.Commands.Update
{
    using MediatR;
    using System.Security.Claims;

    public class LootTreasureCommand : IRequest<string>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
