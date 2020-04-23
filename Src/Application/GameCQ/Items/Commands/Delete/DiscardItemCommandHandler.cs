namespace Application.GameCQ.Items.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class DiscardItemCommandHandler : UserHandler, IRequestHandler<DiscardItemCommand, string>
    {
        public DiscardItemCommandHandler(IFFDbContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
        }

        public async Task<string> Handle(DiscardItemCommand request, CancellationToken cancellationToken)
        {
            var user = await this.UserManager.GetUserAsync(request.User);

            var hero = this.Context.Heroes.FirstOrDefault(u => u.UserId == user.Id && u.IsSelected);

            await this.DiscardItem(request, hero);

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return "/Inventory";
        }

        private async Task DiscardItem(DiscardItemCommand request, Hero hero)
        {
            if (request.Slot == "Weapon")
            {
                var weaponToRemove = await this.Context.WeaponsInventories.FindAsync(request.ItemId);

                if (request.Count >= weaponToRemove.Count)
                {
                    this.Context.WeaponsInventories.Remove(weaponToRemove);
                }
                else
                {
                    weaponToRemove.Count -= request.Count;
                }

                var weapon = await this.Context.Weapons.FindAsync(request.ItemId);

                hero.GoldAmount += weapon.SellPrice * request.Count;
            }
            else if (request.Slot == "Trinket")
            {
                var trinketToRemove = await this.Context.TrinketsInventories.FindAsync(request.ItemId);

                if (request.Count >= trinketToRemove.Count)
                {
                    this.Context.TrinketsInventories.Remove(trinketToRemove);
                }
                else
                {
                    trinketToRemove.Count -= request.Count;
                }

                var trinket = await this.Context.Trinkets.FindAsync(request.ItemId);

                hero.GoldAmount += trinket.SellPrice * request.Count;
            }
            else if (request.Slot == "Material")
            {
                var materialToRemove = await this.Context.MaterialsInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= materialToRemove.Count)
                {
                    this.Context.MaterialsInventories.Remove(materialToRemove);
                }
                else
                {
                    materialToRemove.Count -= request.Count;
                }

                var material = await this.Context.Materials.FindAsync(int.Parse(request.ItemId));

                hero.GoldAmount += material.SellPrice * request.Count;
            }
            else if (request.Slot == "Treasure")
            {
                var treasureToRemove = await this.Context.TreasuresInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= treasureToRemove.Count)
                {
                    this.Context.TreasuresInventories.Remove(treasureToRemove);
                }
                else
                {
                    treasureToRemove.Count -= request.Count;
                }
            }
            else if (request.Slot == "Treasure Key")
            {
                var treasureKeyToRemove = await this.Context.TreasureKeysInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= treasureKeyToRemove.Count)
                {
                    this.Context.TreasureKeysInventories.Remove(treasureKeyToRemove);
                }
                else
                {
                    treasureKeyToRemove.Count -= request.Count;
                }
            }
            else if (request.Slot == "Tool")
            {
                var toolToRemove = await this.Context.ToolsInventories.FindAsync(int.Parse(request.ItemId));

                if (request.Count >= toolToRemove.Count)
                {
                    this.Context.ToolsInventories.Remove(toolToRemove);
                }
                else
                {
                    toolToRemove.Count -= request.Count;
                }

                var tool = await this.Context.Tools.FindAsync(int.Parse(request.ItemId));

                hero.GoldAmount += tool.SellPrice * request.Count;
            }
            else
            {
                var armorToRemove = await this.Context.ArmorsInventories.FindAsync(request.ItemId);

                if (request.Count >= armorToRemove.Count)
                {
                    this.Context.ArmorsInventories.Remove(armorToRemove);
                }
                else
                {
                    armorToRemove.Count -= request.Count;
                }

                var armor = await this.Context.Armors.FindAsync(request.ItemId);

                hero.GoldAmount += armor.SellPrice * request.Count;
            }
        }
    }
}
