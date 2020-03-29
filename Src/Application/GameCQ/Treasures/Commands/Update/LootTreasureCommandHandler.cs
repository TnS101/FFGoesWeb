namespace Application.GameCQ.Treasures.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

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
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var treasure = new Treasure();

            treasure = await this.context.Treasures.FirstOrDefaultAsync(r => r.Rarity == this.TreasureRarity());

            hero.Inventory.TreasureInventories.Add(new TreasureInventory
            {
                InventoryId = hero.InventoryId,
                TreasureId = treasure.Id,
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return GConst.WorldRedirect;
        }

        private string TreasureRarity()
        {
            var rng = new Random();

            int treasureNumber = rng.Next(0, 10);

            if (treasureNumber >= 0 && treasureNumber < 5)
            {
                return "Bronze";
            }
            else if (treasureNumber >= 5 && treasureNumber < 8)
            {
                return "Silver";
            }
            else
            {
                return "Gold";
            }
        }
    }
}
