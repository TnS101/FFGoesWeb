namespace Application.GameCQ.Items.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DiscardItemCommandHandler : BaseHandler, IRequestHandler<DiscardItemCommand, string>
    {
        public DiscardItemCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DiscardItemCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            await this.DiscardItem(request, hero);

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.InventoryCommandRedirect, hero.Id, request.Slot);
        }

        private async Task DiscardItem(DiscardItemCommand request, Hero hero)
        {
            if (request.Slot == "Weapon")
            {
                var weaponToRemove = await this.Context.WeaponsInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.WeaponId == request.ItemId);

                int count;

                if (request.Count >= weaponToRemove.Count)
                {
                    this.Context.WeaponsInventories.Remove(weaponToRemove);
                    count = weaponToRemove.Count;
                }
                else
                {
                    weaponToRemove.Count -= request.Count;
                    count = request.Count;
                }

                var weapon = await this.Context.Weapons.FindAsync(request.ItemId);

                hero.GoldAmount += weapon.SellPrice * count;
            }
            else if (request.Slot == "Trinket")
            {
                var trinketToRemove = await this.Context.TrinketsInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.TrinketId == request.ItemId);

                int count;

                if (request.Count >= trinketToRemove.Count)
                {
                    this.Context.TrinketsInventories.Remove(trinketToRemove);
                    count = trinketToRemove.Count;
                }
                else
                {
                    trinketToRemove.Count -= request.Count;
                    count = request.Count;
                }

                var trinket = await this.Context.Trinkets.FindAsync(request.ItemId);

                hero.GoldAmount += trinket.SellPrice * count;
            }
            else if (request.Slot == "Material")
            {
                var materialToRemove = await this.Context.MaterialsInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.MaterialId == int.Parse(request.ItemId));

                int count;

                if (request.Count >= materialToRemove.Count)
                {
                    this.Context.MaterialsInventories.Remove(materialToRemove);
                    count = materialToRemove.Count;
                }
                else
                {
                    materialToRemove.Count -= request.Count;
                    count = request.Count;
                }

                var material = await this.Context.Materials.FindAsync(int.Parse(request.ItemId));

                hero.GoldAmount += material.SellPrice * count;
            }
            else if (request.Slot == "Treasure")
            {
                var treasureToRemove = await this.Context.TreasuresInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.TreasureId == int.Parse(request.ItemId));

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
                var treasureKeyToRemove = await this.Context.TreasureKeysInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.TreasureKeyId == int.Parse(request.ItemId));

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
                var toolToRemove = await this.Context.ToolsInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.ToolId == int.Parse(request.ItemId));

                int count;

                if (request.Count >= toolToRemove.Count)
                {
                    this.Context.ToolsInventories.Remove(toolToRemove);
                    count = toolToRemove.Count;
                }
                else
                {
                    toolToRemove.Count -= request.Count;
                    count = request.Count;
                }

                var tool = await this.Context.Tools.FindAsync(int.Parse(request.ItemId));

                hero.GoldAmount += tool.SellPrice * count;
            }
            else
            {
                var armorToRemove = await this.Context.ArmorsInventories.FirstOrDefaultAsync(i => i.InventoryId == hero.InventoryId && i.ArmorId == request.ItemId);

                int count;

                if (request.Count >= armorToRemove.Count)
                {
                    this.Context.ArmorsInventories.Remove(armorToRemove);
                    count = armorToRemove.Count;
                }
                else
                {
                    armorToRemove.Count -= request.Count;
                    count = request.Count;
                }

                var armor = await this.Context.Armors.FindAsync(request.ItemId);

                hero.GoldAmount += armor.SellPrice * count;
            }
        }
    }
}
