namespace Application.CQ.Admin.GameContent.Items.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Domain.Contracts.Items;
    using global::Common;
    using MediatR;

    public class UpdateItemCommandHandler : BaseHandler, IRequestHandler<UpdateItemCommand, string>
    {
        public UpdateItemCommandHandler(IFFDbContext context)
            : base(context)
        {
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

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminItemCommandRedirectId, request.Id, request.Slot);
        }

        private async Task WeaponUpdate(UpdateItemCommand request)
        {
            var weapon = await this.Context.Weapons.FindAsync(request.Id);

            if (request.NewAttackPower > 0)
            {
                weapon.AttackPower = request.NewAttackPower;
            }

            this.EquipableItemNullCheck(request, weapon);

            this.Context.Weapons.Update(weapon);
        }

        private async Task ArmorUpdate(UpdateItemCommand request)
        {
            var armor = await this.Context.Armors.FindAsync(request.Id);

            if (request.NewArmorValue > 0)
            {
                armor.ArmorValue = request.NewArmorValue;
            }

            if (request.NewResistanceValue > 0)
            {
                armor.ResistanceValue = request.NewResistanceValue;
            }

            this.EquipableItemNullCheck(request, armor);

            this.Context.Armors.Update(armor);
        }

        private async Task TrinketUpdate(UpdateItemCommand request)
        {
            var trinket = await this.Context.Trinkets.FindAsync(request.Id);

            this.EquipableItemNullCheck(request, trinket);

            this.Context.Trinkets.Update(trinket);
        }

        private async Task MaterialUpdate(UpdateItemCommand request)
        {
            var material = await this.Context.Materials.FindAsync(int.Parse(request.Id));

            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                material.Name = request.NewName;
            }

            if (request.NewBuyPrice != 0)
            {
                material.BuyPrice = request.NewBuyPrice;
            }

            if (request.NewSellPrice != 0)
            {
                material.SellPrice = request.NewSellPrice;
            }

            if (request.NewFuelCount != 0)
            {
                material.FuelCount = request.NewFuelCount;
            }

            if (!string.IsNullOrWhiteSpace(request.NewRelatedMaterials))
            {
                material.RelatedMaterials = request.NewRelatedMaterials;
            }

            if (!string.IsNullOrWhiteSpace(request.NewMaterialDiversity))
            {
                if (request.NewMaterialDiversity == "craftable")
                {
                    material.IsCraftable = true;

                    material.IsRefineable = false;
                    material.IsDisolveable = false;

                    material.ToolId = request.NewToolId;
                }
                else if (request.NewMaterialDiversity == "disolveable")
                {
                    material.IsDisolveable = true;

                    material.IsDisolveable = false;
                    material.IsCraftable = false;

                    material.ToolId = request.NewToolId;
                }
                else if (request.NewMaterialDiversity == "refineable")
                {
                    material.IsRefineable = true;

                    material.IsCraftable = false;
                    material.IsRefineable = false;

                    material.ToolId = request.NewToolId;
                }
            }

            if (!string.IsNullOrWhiteSpace(request.NewMaterialType))
            {
                material.Type = request.NewMaterialType;
            }

            this.Context.Materials.Update(material);
        }

        private async Task TreasureUpdate(UpdateItemCommand request)
        {
            var treasure = await this.Context.Treasures.FindAsync(int.Parse(request.Id));

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

            this.Context.Treasures.Update(treasure);
        }

        private async Task TreasureKeyUpdate(UpdateItemCommand request)
        {
            var treasureKey = await this.Context.TreasureKeys.FindAsync(int.Parse(request.Id));

            if (!string.IsNullOrWhiteSpace(request.NewName))
            {
                treasureKey.Name = request.NewName;
            }

            if (!string.IsNullOrWhiteSpace(request.NewRarity))
            {
                treasureKey.Rarity = request.NewRarity;
            }

            this.Context.TreasureKeys.Update(treasureKey);
        }

        private async Task ToolUpdate(UpdateItemCommand request)
        {
            var tool = await this.Context.Tools.FindAsync(int.Parse(request.Id));

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

            this.Context.Tools.Update(tool);
        }

        private void EquipableItemNullCheck(UpdateItemCommand request, IEquipableItem item)
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
