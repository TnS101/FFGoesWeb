namespace Application.GameCQ.LootBoxes.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class OpenTreasureCommandHandler : BaseHandler, IRequestHandler<OpenTreasureCommand, string>
    {
        public OpenTreasureCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(OpenTreasureCommand request, CancellationToken cancellationToken)
        {
            var user = await this.Context.AppUsers.FindAsync(request.UserId);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var treasure = await this.Context.LootBoxes.FindAsync(request.Id);

            var treasureKey = await this.Context.LootKeys.FirstOrDefaultAsync(t => t.Rarity == treasure.Rarity);

            return await this.OpenChest(hero, treasureKey, treasure, cancellationToken);
        }

        private async Task<string> OpenChest(Hero hero, LootKey treasureKey, LootBox treasure, CancellationToken cancellationToken)
        {
            if (hero.Inventory.LootKeyInventories.Any(t => t.LootKeyId == treasureKey.Id))
            {
                var treasureKeyToRemove = await this.Context.TreasureKeysInventories.FirstOrDefaultAsync(t => t.LootKeyId == treasureKey.Id);

                var treasureToRemove = await this.Context.TreasuresInventories.FirstOrDefaultAsync(t => t.LootBoxId == treasureKey.Id);

                hero.GoldAmount += treasure.Reward;

                this.Context.TreasureKeysInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Remove(treasureKeyToRemove);

                this.Context.TreasuresInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Remove(treasureToRemove);
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
