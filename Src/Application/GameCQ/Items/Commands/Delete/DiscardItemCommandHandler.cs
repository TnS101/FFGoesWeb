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

            await this.DiscardItem(request, hero);

            this.context.Heroes.Update(hero);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }

        private async Task DiscardItem(DiscardItemCommand request, Hero hero)
        {
            if (request.Slot == "Weapon")
            {
                var weaponToRemove = await this.context.WeaponsInventories.FindAsync(request.ItemId);

                if (request.Count >= weaponToRemove.Count)
                {
                    this.context.WeaponsInventories.Remove(weaponToRemove);
                }
                else
                {
                    weaponToRemove.Count -= request.Count;
                }

                var weapon = await this.context.Weapons.FindAsync(request.ItemId);

                hero.GoldAmount += weapon.SellPrice * request.Count;
            }
            else if (request.Slot == "Trinket")
            {
                var trinketToRemove = await this.context.TrinketsInventories.FindAsync(request.ItemId);

                if (request.Count >= trinketToRemove.Count)
                {
                    this.context.TrinketsInventories.Remove(trinketToRemove);
                }
                else
                {
                    trinketToRemove.Count -= request.Count;
                }

                var trinket = await this.context.Trinkets.FindAsync(request.ItemId);

                hero.GoldAmount += trinket.SellPrice * request.Count;
            }
            else if (request.Slot == "Material")
            {
                var materialToRemove = await this.context.MaterialsInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= materialToRemove.Count)
                {
                    this.context.MaterialsInventories.Remove(materialToRemove);
                }
                else
                {
                    materialToRemove.Count -= request.Count;
                }

                var material = await this.context.Materials.FindAsync(int.Parse(request.ItemId));

                hero.GoldAmount += material.SellPrice * request.Count;
            }
            else if (request.Slot == "Treasure")
            {
                var treasureToRemove = await this.context.TreasuresInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= treasureToRemove.Count)
                {
                    this.context.TreasuresInventories.Remove(treasureToRemove);
                }
                else
                {
                    treasureToRemove.Count -= request.Count;
                }
            }
            else if (request.Slot == "Treasure Key")
            {
                var treasureKeyToRemove = await this.context.TreasureKeysInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= treasureKeyToRemove.Count)
                {
                    this.context.TreasureKeysInventories.Remove(treasureKeyToRemove);
                }
                else
                {
                    treasureKeyToRemove.Count -= request.Count;
                }
            }
            else if (request.Slot == "Tool")
            {
                var toolToRemove = await this.context.ToolsInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= toolToRemove.Count)
                {
                    this.context.ToolsInventories.Remove(toolToRemove);
                }
                else
                {
                    toolToRemove.Count -= request.Count;
                }

                var tool = await this.context.Tools.FindAsync(int.Parse(request.ItemId));

                hero.GoldAmount += tool.SellPrice * request.Count;
            }
            else
            {
                var armorToRemove = await this.context.ArmorsInventories.FindAsync(request.ItemId);

                if (request.Count >= armorToRemove.Count)
                {
                    this.context.ArmorsInventories.Remove(armorToRemove);
                }
                else
                {
                    armorToRemove.Count -= request.Count;
                }

                var armor = await this.context.Armors.FindAsync(request.ItemId);

                hero.GoldAmount += armor.SellPrice * request.Count;
            }
        }
    }
}
