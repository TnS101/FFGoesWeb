﻿namespace Application.GameCQ.LootBoxes.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class LootLootBoxCommandHandler : BaseHandler, IRequestHandler<LootLootBoxCommand, string>
    {
        public LootLootBoxCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(LootLootBoxCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == request.UserId && u.IsSelected);

            var lootBoxType = this.LootBoxType(rng);

            var lootBoxes = await this.Context.LootBoxes.Where(lb => lb.Type == lootBoxType).ToArrayAsync();

            var lootBoxId = lootBoxes[rng.Next(lootBoxes.Length)].Id;

            this.Context.LootBoxesInventories.Add(new LootBoxInventory
            {
                HeroId = hero.Id,
                LootBoxId = lootBoxId,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }

        private string LootBoxType(Random rng)
        {
            int treasureNumber = rng.Next(29);

            if (treasureNumber >= 0 && treasureNumber <= 4)
            {
                return "Bronze";
            }
            else if (treasureNumber >= 5 && treasureNumber <= 8)
            {
                return "Silver";
            }
            else if (treasureNumber >= 9 && treasureNumber <= 11)
            {
                return "Material";
            }
            else if (treasureNumber >= 12 && treasureNumber <= 14)
            {
                return "Consumeable";
            }
            else if (treasureNumber >= 15 && treasureNumber <= 17)
            {
                return "Tool";
            }
            else if (treasureNumber >= 18 && treasureNumber <= 20)
            {
                return "Junk";
            }
            else if (treasureNumber >= 21 && treasureNumber <= 23)
            {
                return "Toy";
            }
            else if (treasureNumber >= 24 && treasureNumber <= 26)
            {
                return "Key";
            }
            else
            {
                return "Golden";
            }
        }
    }
}
