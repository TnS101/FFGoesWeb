namespace Application.GameCQ.Treasures.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class LootTreasureCommandHandler : UserHandler, IRequestHandler<LootTreasureCommand, string>
    {
        public LootTreasureCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(LootTreasureCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var treasure = new Treasure();

            treasure = await this.Context.Treasures.FirstOrDefaultAsync(r => r.Rarity == this.TreasureRarity());

            hero.Inventory.TreasureInventories.Add(new TreasureInventory
            {
                InventoryId = hero.InventoryId,
                TreasureId = treasure.Id,
            });

            await this.Context.SaveChangesAsync(cancellationToken);

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
