namespace Application.CQ.Admin.GameContent.Items.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
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

            this.NullCheck(request, weapon);

            this.BaseStatsSet(request, weapon);

            weapon.AttackPower = request.NewAttackPower;

            this.context.Weapons.Update(weapon);
        }

        private async Task ArmorUpdate(UpdateItemCommand request)
        {
            var armor = await this.context.Armors.FindAsync(request.Id);

            this.NullCheck(request, armor);

            this.BaseStatsSet(request, armor);

            armor.ArmorValue = request.NewArmorValue;

            armor.RessistanceValue = request.NewRessistanceValue;

            this.context.Armors.Update(armor);
        }

        private async Task TrinketUpdate(UpdateItemCommand request)
        {
            var trinket = await this.context.Trinkets.FindAsync(request.Id);

            this.NullCheck(request, trinket);

            this.BaseStatsSet(request, trinket);

            this.context.Trinkets.Update(trinket);
        }

        private async Task MaterialUpdate(UpdateItemCommand request)
        {
            var material = await this.context.Materials.FindAsync(request.Id);

            this.NullCheck(request, material);

            material.SellPrice = request.NewSellPrice;

            material.BuyPrice = request.NewBuyPrice;

            this.context.Materials.Update(material);
        }

        private async Task TreasureUpdate(UpdateItemCommand request)
        {
            var treasure = await this.context.Treasures.FindAsync(request.Id);

            this.NullCheck(request, treasure);

            treasure.Rarity = request.Rarity;

            treasure.Reward = request.Reward;

            this.context.Treasures.Update(treasure);
        }

        private async Task TreasureKeyUpdate(UpdateItemCommand request)
        {
            var treasureKey = await this.context.TreasureKeys.FindAsync(request.Id);

            this.NullCheck(request, treasureKey);

            treasureKey.Rarity = request.Rarity;

            this.context.TreasureKeys.Update(treasureKey);
        }

        private void BaseStatsSet(UpdateItemCommand request, Domain.Base.Item item)
        {
            item.Name = request.NewName;
            item.Level = request.NewLevel;
            item.ClassType = request.NewClassType;
            item.Stamina = request.NewStamina;
            item.Strength = request.NewStrength;
            item.Agility = request.NewAgility;
            item.Intellect = request.NewIntellect;
            item.Spirit = request.NewSpirit;
            item.SellPrice = request.NewSellPrice;
            item.BuyPrice = request.NewBuyPrice;
        }

        private void NullCheck(UpdateItemCommand request, Domain.Base.Item item)
        {
            if (string.IsNullOrWhiteSpace(request.NewName))
            {
                request.NewName = item.Name;
            }

            if (item.Slot != "Treasure" && item.Slot != "Treasure Key")
            {
                if (request.NewBuyPrice == 0)
                {
                    request.NewBuyPrice = item.BuyPrice;
                }

                if (request.NewSellPrice == 0)
                {
                    request.NewSellPrice = item.SellPrice;
                }
            }
            else if (item.Slot != "Material")
            {
                if (request.NewLevel == 0)
                {
                    request.NewLevel = item.Level;
                }

                if (string.IsNullOrWhiteSpace(request.NewClassType))
                {
                    request.NewClassType = item.ClassType;
                }

                if (request.NewStamina == 0)
                {
                    request.NewStamina = item.Stamina;
                }

                if (request.NewStrength == 0)
                {
                    request.NewStrength = item.Strength;
                }

                if (request.NewAgility == 0)
                {
                    request.NewAgility = item.Agility;
                }

                if (request.NewIntellect == 0)
                {
                    request.NewIntellect = item.Intellect;
                }

                if (request.NewSpirit == 0)
                {
                    request.NewSpirit = item.Spirit;
                }

                if (item.Slot == "Treasure")
                {
                    if (string.IsNullOrWhiteSpace(request.Rarity))
                    {
                        request.Rarity = item.Rarity;
                    }

                    if (request.Reward == 0)
                    {
                        request.Reward = item.Reward;
                    }
                }

                if (item.Slot == "Treasure Key")
                {
                    if (request.Reward == 0)
                    {
                        request.Reward = item.Reward;
                    }
                }

                if (item.Slot == "Weapon")
                {
                    if (request.NewAttackPower == 0)
                    {
                        request.NewAttackPower = item.AttackPower;
                    }
                }
                else if (item.Slot != "Trinket")
                {
                    if (request.NewArmorValue == 0)
                    {
                        request.NewArmorValue = item.ArmorValue;
                    }

                    if (request.NewRessistanceValue == 0)
                    {
                        request.NewRessistanceValue = item.ArmorValue;
                    }
                }
            }
        }
    }
}
