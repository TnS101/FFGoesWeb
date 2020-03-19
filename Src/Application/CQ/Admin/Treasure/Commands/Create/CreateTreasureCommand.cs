﻿namespace Application.CQ.Admin.Treasure.Commands.Create
{
    using MediatR;

    public class CreateTreasureCommand : IRequest
    {
        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImageURL { get; set; }
    }
}