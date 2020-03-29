namespace Application.GameCQ.Items.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class DiscardItemCommandHandler : IRequestHandler<DiscardItemCommand, string>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;

        public DiscardItemCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> Handle(DiscardItemCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var hero = this.context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            await this.RemoveItem(request, hero);

            this.context.Inventories.Update(hero.Inventory);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }

        private async Task RemoveItem(DiscardItemCommand request, Hero hero)
        {
            if (request.Slot == "Weapon")
            {
                var weaponToRemove = await this.context.WeaponsInventories.FindAsync(request.ItemId);
                hero.Inventory.WeaponInventories.Where(wi => wi.InventoryId == hero.InventoryId).ToList().Remove(weaponToRemove);
            }
            else if (request.Slot == "Trinket")
            {
                var trinketToRemove = await this.context.TrinketsInventories.FindAsync(request.ItemId);
                hero.Inventory.TrinketInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToList().Remove(trinketToRemove);
            }
            else if (request.Slot == "Material")
            {
                var materialToRemove = await this.context.MaterialsInventories.FindAsync(request.ItemId);
                hero.Inventory.MaterialInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToList().Remove(materialToRemove);
            }
            else if (request.Slot == "Treasure")
            {
                var treasureToRemove = await this.context.TreasuresInventories.FindAsync(request.ItemId);
                hero.Inventory.TreasureInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToList().Remove(treasureToRemove);
            }
            else if (request.Slot == "Treasure Key")
            {
                var treasureKeyToRemove = await this.context.TreasureKeysInventories.FindAsync(request.ItemId);
                hero.Inventory.TreasureKeyInventories.Where(ti => ti.InventoryId == hero.InventoryId).ToList().Remove(treasureKeyToRemove);
            }
            else
            {
                var armorToRemove = await this.context.ArmorsInventories.FindAsync(request.ItemId);
                hero.Inventory.ArmorInventories.Where(ai => ai.InventoryId == hero.InventoryId).ToList().Remove(armorToRemove);
            }
        }
    }
}
