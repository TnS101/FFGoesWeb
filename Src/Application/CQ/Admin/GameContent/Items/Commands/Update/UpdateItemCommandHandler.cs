namespace Application.CQ.Admin.GameContent.Items.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Contracts.Items.AdditionalTypes;
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
            else
            {
                await this.ArmorUpdate(request);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminItemCommandRedirect, request.Slot);
        }

        private async Task WeaponUpdate(UpdateItemCommand request)
        {
            var weapon = await this.context.Weapons.FindAsync(request.Id);

            if (request.NewAttackPower > 0)
            {
                weapon.AttackPower = request.NewAttackPower;
            }

            this.BaseItemsNullCheck(request, weapon);

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

            this.BaseItemsNullCheck(request, armor);

            this.context.Armors.Update(armor);
        }

        private async Task TrinketUpdate(UpdateItemCommand request)
        {
            var trinket = await this.context.Trinkets.FindAsync(request.Id);

            this.BaseItemsNullCheck(request, trinket);

            this.context.Trinkets.Update(trinket);
        }

        private async Task MaterialUpdate(UpdateItemCommand request)
        {
            var material = await this.context.Materials.FindAsync(request.Id);

            this.MaterialStatsHandler(request, material);

            this.context.Materials.Update(material);
        }

        private async Task TreasureUpdate(UpdateItemCommand request)
        {
            var treasure = await this.context.Treasures.FindAsync(request.Id);

            this.TreasureStatsHandler(request, treasure);

            if (request.Reward > 0)
            {
                treasure.Reward = request.Reward;
            }

            this.context.Treasures.Update(treasure);
        }

        private async Task TreasureKeyUpdate(UpdateItemCommand request)
        {
            var treasureKey = await this.context.TreasureKeys.FindAsync(request.Id);

            this.TreasureStatsHandler(request, treasureKey);

            treasureKey.Rarity = request.Rarity;

            this.context.TreasureKeys.Update(treasureKey);
        }

        private void TreasureStatsHandler(UpdateItemCommand request, ITreasure treasure)
        {
            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                treasure.Name = request.NewName;
            }

            if (!string.IsNullOrWhiteSpace(request.Rarity))
            {
                treasure.Rarity = request.Rarity;
            }
        }

        private void MaterialStatsHandler(UpdateItemCommand request, IMaterial material)
        {
            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                material.Name = request.NewName;
            }

            if (request.NewBuyPrice > 0)
            {
                material.BuyPrice = request.NewBuyPrice;
            }

            if (request.NewSellPrice > 0)
            {
                material.SellPrice = request.NewSellPrice;
            }
        }

        private void BaseItemsNullCheck(UpdateItemCommand request, IBaseItem item)
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
