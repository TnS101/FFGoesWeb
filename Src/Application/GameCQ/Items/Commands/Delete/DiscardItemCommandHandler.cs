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
                var weaponToRemove = await this.context.Weapons.FindAsync(request.ItemId);
                hero.Inventory.Weapons.Remove(weaponToRemove);
            }
            else if (request.Slot == "Trinket")
            {
                var trinketToRemove = await this.context.Trinkets.FindAsync(request.ItemId);
                hero.Inventory.Trinkets.Remove(trinketToRemove);
            }
            else if (request.Slot == "Material")
            {
                var materialToRemove = await this.context.Materials.FindAsync(request.ItemId);
                hero.Inventory.Materials.Remove(materialToRemove);
            }
            else if (request.Slot == "Treasure")
            {
                var treasureToRemove = await this.context.Treasures.FindAsync(request.ItemId);
                hero.Inventory.Treasures.Remove(treasureToRemove);
            }
            else if (request.Slot == "Treasure Key")
            {
                var treasureKeyToRemove = await this.context.TreasureKeys.FindAsync(request.ItemId);
                hero.Inventory.TreasureKeys.Remove(treasureKeyToRemove);
            }
            else
            {
                var armorToRemove = await this.context.Armors.FindAsync(request.ItemId);
                hero.Inventory.Armors.Remove(armorToRemove);
            }
        }
    }
}
