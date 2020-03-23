namespace Application.GameCQ.Treasure.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class LootTreasureCommandHandler : IRequestHandler<LootTreasureCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public LootTreasureCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(LootTreasureCommand request, CancellationToken cancellationToken)
        {
            var rng = new Random();

            int treasureNumber = rng.Next(0, 10);

            var user = await this.userManager.GetUserAsync(request.User);

            var unit = this.context.Units.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            string rarity = string.Empty;

            if (treasureNumber >= 0 && treasureNumber < 5)
            {
                rarity = "Bronze";
            }
            else if (treasureNumber >= 5 && treasureNumber < 8)
            {
                rarity = "Silver";
            }
            else
            {
                rarity = "Gold";
            }

            var treasure = this.context.Treasures.FirstOrDefault(t => t.Rarity == rarity);

            this.context.Items.Where(i => i.InventoryId == unit.InventoryId).ToList().Add(treasure);

            await this.context.SaveChangesAsync(cancellationToken);

            return rarity;
        }
    }
}
