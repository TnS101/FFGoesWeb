namespace Application.GameCQ.Treasures.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class OpenTreasureCommandHandler : IRequestHandler<OpenTreasureCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public OpenTreasureCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(OpenTreasureCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            var treasure = await this.context.Treasures.FindAsync(request.Id);

            var treasureKey = await this.context.TreasureKeys.FirstOrDefaultAsync(t => t.Rarity == treasure.Rarity);

            return await this.OpenChest(hero, treasureKey, treasure, cancellationToken);
        }

        private async Task<string> OpenChest(Hero hero, TreasureKey treasureKey, Treasure treasure, CancellationToken cancellationToken)
        {
            if (hero.Inventory.TreasureKeyInventories.Any(t => t.TreasureKeyId == treasureKey.Id))
            {
                var treasureKeyToRemove = await this.context.TreasureKeysInventories.FirstOrDefaultAsync(t => t.TreasureKeyId == treasureKey.Id);

                var treasureToRemove = await this.context.TreasuresInventories.FirstOrDefaultAsync(t => t.TreasureId == treasureKey.Id);

                hero.GoldAmount += treasure.Reward;

                this.context.TreasureKeysInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Remove(treasureKeyToRemove);

                this.context.TreasuresInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Remove(treasureToRemove);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }
    }
}
