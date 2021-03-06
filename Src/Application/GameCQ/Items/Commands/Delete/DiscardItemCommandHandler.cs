﻿namespace Application.GameCQ.Items.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DiscardItemCommandHandler : BaseHandler, IRequestHandler<DiscardItemCommand, DiscardItemJsonResult>
    {
        public DiscardItemCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<DiscardItemJsonResult> Handle(DiscardItemCommand request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            var reward = await this.DiscardItem(request, hero);

            this.Context.Heroes.Update(hero);

            await this.Context.SaveChangesAsync(cancellationToken);

            return new DiscardItemJsonResult { Reward = reward, ItemId = request.ItemId };
        }

        private async Task<int> DiscardItem(DiscardItemCommand request, Hero hero)
        {
            int reward = 0;

            if (request.Slot == "Weapon")
            {
                var weaponToRemove = await this.Context.WeaponsInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.WeaponId == request.ItemId);

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

                reward = weapon.SellPrice * count;
            }
            else if (request.Slot == "Trinket")
            {
                var trinketToRemove = await this.Context.TrinketsInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.TrinketId == request.ItemId);

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

                reward = trinket.SellPrice * count;
            }
            else if (request.Slot == "Material")
            {
                var materialToRemove = await this.Context.MaterialsInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.MaterialId == (int)request.ItemId);

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

                var material = await this.Context.Materials.FindAsync((int)request.ItemId);

                reward = material.SellPrice * count;
            }
            else if (request.Slot == "Treasure")
            {
                var treasureToRemove = await this.Context.LootBoxesInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.LootBoxId == (int)request.ItemId);

                if (request.Count >= treasureToRemove.Count)
                {
                    this.Context.LootBoxesInventories.Remove(treasureToRemove);
                }
                else
                {
                    treasureToRemove.Count -= request.Count;
                }
            }
            else if (request.Slot == "Treasure Key")
            {
                var treasureKeyToRemove = await this.Context.LootKeysInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.LootKeyId == (int)request.ItemId);

                if (request.Count >= treasureKeyToRemove.Count)
                {
                    this.Context.LootKeysInventories.Remove(treasureKeyToRemove);
                }
                else
                {
                    treasureKeyToRemove.Count -= request.Count;
                }
            }
            else if (request.Slot == "Tool")
            {
                var toolToRemove = await this.Context.ToolsInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.ToolId == (int)request.ItemId);

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

                var tool = await this.Context.Tools.FindAsync((int)request.ItemId);

                reward = tool.SellPrice * count;
            }
            else
            {
                var armorToRemove = await this.Context.ArmorsInventories.FirstOrDefaultAsync(i => i.HeroId == hero.Id && i.ArmorId == request.ItemId);

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

                reward = armor.SellPrice * count;
            }

            hero.CoinAmount += reward;

            return reward;
        }
    }
}
