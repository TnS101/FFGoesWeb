namespace Application.CQ.Admin.GameContent.Items.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Base;
    using Domain.Contracts.Items;
    using global::Common;
    using MediatR;

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, string>
    {
        private readonly IFFDbContext context;

        public UpdateItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                await this.WeaponUpdate(request);
            }
            else if (request.Slot == "Trinket")
            {
                await this.TrinketUpdate(request);
            }
            else if (request.Slot == "Material")
            {
                await this.MaterialUpdate(request);
            }
            else if (request.Slot == "Treasure")
            {
                await this.TreasureUpdate(request);
            }
            else if (request.Slot == "Treasure Key")
            {
                await this.TreasureKeyUpdate(request);
            }
            else if (request.Slot == "Tool")
            {
                await this.ToolUpdate(request);
            }
            else
            {
                await this.ArmorUpdate(request);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminItemCommandRedirectId, request.Slot);
        }

        private async Task WeaponUpdate(UpdateItemCommand request)
        {
            var weapon = await this.context.Weapons.FindAsync(request.Id);

            if (request.NewAttackPower > 0)
            {
                weapon.AttackPower = request.NewAttackPower;
            }

            this.BaseStatsNullCheck(request, weapon);

            this.context.Weapons.Update(weapon);
        }

        private async Task ArmorUpdate(UpdateItemCommand request)
        {
            var armor = await this.context.Armors.FindAsync(request.Id);

            if (request.NewArmorValue > 0)
            {
                armor.ArmorValue = request.NewArmorValue;
            }

            if (request.NewResistanceValue > 0)
            {
                armor.ResistanceValue = request.NewResistanceValue;
            }

            this.BaseStatsNullCheck(request, armor);

            this.context.Armors.Update(armor);
        }

        private async Task TrinketUpdate(UpdateItemCommand request)
        {
            var trinket = await this.context.Trinkets.FindAsync(request.Id);

            this.BaseStatsNullCheck(request, trinket);

            this.context.Trinkets.Update(trinket);
        }

        private async Task MaterialUpdate(UpdateItemCommand request)
        {
            var material = await this.context.Materials.FindAsync(int.Parse(request.Id));

            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                material.Name = request.NewName;
            }

            if (request.IsCraftable)
            {
                material.IsCraftable = true;

                material.IsRefineable = false;
                material.IsDisolveable = false;
            }
            else if (request.IsRefineable)
            {
                material.IsRefineable = true;

                material.IsDisolveable = false;
                material.IsCraftable = false;
            }
            else
            {
                material.IsDisolveable = true;

                material.IsCraftable = false;
                material.IsRefineable = false;
            }

            if (request.NewBuyPrice != 0)
            {
                material.BuyPrice = request.NewBuyPrice;
            }

            if (request.NewSellPrice != 0)
            {
                material.SellPrice = request.NewSellPrice;
            }

            this.context.Materials.Update(material);
        }

        private async Task TreasureUpdate(UpdateItemCommand request)
        {
            var treasure = await this.context.Treasures.FindAsync(int.Parse(request.Id));

            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                treasure.Name = request.NewName;
            }

            if (request.NewReward > 0)
            {
                treasure.Reward = request.NewReward;
            }

            if (!string.IsNullOrWhiteSpace(request.NewRarity))
            {
                treasure.Rarity = request.NewRarity;
            }

            this.context.Treasures.Update(treasure);
        }

        private async Task TreasureKeyUpdate(UpdateItemCommand request)
        {
            var treasureKey = await this.context.TreasureKeys.FindAsync(int.Parse(request.Id));

            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                treasureKey.Name = request.NewName;
            }

            if (!string.IsNullOrWhiteSpace(request.NewRarity))
            {
                treasureKey.Rarity = request.NewRarity;
            }

            this.context.TreasureKeys.Update(treasureKey);
        }

        private async Task ToolUpdate(UpdateItemCommand request)
        {
            var tool = await this.context.Tools.FindAsync(int.Parse(request.Id));

            if (request.NewDurability > 0)
            {
                tool.Durability = request.NewDurability;
            }

            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                tool.Name = request.NewName;
            }

            if (request.NewBuyPrice != 0)
            {
                tool.BuyPrice = request.NewBuyPrice;
            }

            if (request.NewSellPrice != 0)
            {
                tool.SellPrice = request.NewSellPrice;
            }

            this.context.Tools.Update(tool);
        }

        private void BaseStatsNullCheck(UpdateItemCommand request, IEquipableItem item)
        {
            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                item.Name = request.NewName;
            }

            if (request.NewBuyPrice > 0)
            {
                item.BuyPrice = request.NewBuyPrice;
            }

            if (request.NewSellPrice > 0)
            {
                item.SellPrice = request.NewSellPrice;
            }

            if (request.NewLevel > 0)
            {
                item.Level = request.NewLevel;
            }

            if (!string.IsNullOrWhiteSpace(request.NewClassType))
            {
                item.ClassType = request.NewClassType;
            }

            if (request.NewStamina > 0)
            {
                item.Stamina = request.NewStamina;
            }

            if (request.NewStrength > 0)
            {
                item.Strength = request.NewStrength;
            }

            if (request.NewAgility > 0)
            {
                item.Agility = request.NewAgility;
            }

            if (request.NewIntellect > 0)
            {
                item.Intellect = request.NewIntellect;
            }

            if (request.NewSpirit > 0)
            {
                item.Spirit = request.NewSpirit;
            }

            
        }
    }
}
