namespace Application.CQ.Admin.GameContent.Items.Queries.GetCurrentItemQuery
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using MediatR;

    public class GetCurrentItemQueryHandler : BaseHandler, IRequestHandler<GetCurrentItemQuery, ItemFullViewModel>
    {
        public GetCurrentItemQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<ItemFullViewModel> Handle(GetCurrentItemQuery request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                return await this.GetWeapon(request);
            }
            else if (request.Slot == "Trinket")
            {
                return await this.GetTrinket(request);
            }
            else if (request.Slot == "Material")
            {
                return await this.GetMaterial(request);
            }
            else if (request.Slot == "Loot Box")
            {
                return await this.GetLootBox(request);
            }
            else if (request.Slot == "Loot Key")
            {
                return await this.GetLootKey(request);
            }
            else if (request.Slot == "Tool")
            {
                return await this.GetTool(request);
            }
            else
            {
                return await this.GetArmor(request);
            }
        }

        private async Task<ItemFullViewModel> GetWeapon(GetCurrentItemQuery request)
        {
            var weapon = await this.Context.Weapons.FindAsync(request.ItemId);

            return new ItemFullViewModel
            {
                Id = weapon.Id,
                Name = weapon.Name,
                ClassType = weapon.ClassType,
                Level = weapon.Level,
                AttackPower = weapon.AttackPower,
                Stamina = weapon.Stamina,
                Strength = weapon.Strength,
                Agility = weapon.Agility,
                Intellect = weapon.Intellect,
                Spirit = weapon.Spirit,
                BuyPrice = weapon.BuyPrice,
                SellPrice = weapon.SellPrice,
                Slot = weapon.Slot,
                ImagePath = weapon.ImagePath,
            };
        }

        private async Task<ItemFullViewModel> GetArmor(GetCurrentItemQuery request)
        {
            var armor = await this.Context.Armors.FindAsync(request.ItemId);

            return new ItemFullViewModel
            {
                Id = armor.Id,
                Name = armor.Name,
                ClassType = armor.ClassType,
                Level = armor.Level,
                ArmorValue = armor.ArmorValue,
                ResistanceValue = armor.ResistanceValue,
                Stamina = armor.Stamina,
                Strength = armor.Strength,
                Agility = armor.Agility,
                Intellect = armor.Intellect,
                Spirit = armor.Spirit,
                BuyPrice = armor.BuyPrice,
                SellPrice = armor.SellPrice,
                Slot = armor.Slot,
                ImagePath = armor.ImagePath,
            };
        }

        private async Task<ItemFullViewModel> GetTrinket(GetCurrentItemQuery request)
        {
            var trinket = await this.Context.Trinkets.FindAsync(request.ItemId);

            return new ItemFullViewModel
            {
                Id = trinket.Id,
                Name = trinket.Name,
                ClassType = trinket.ClassType,
                Level = trinket.Level,
                Stamina = trinket.Stamina,
                Strength = trinket.Strength,
                Agility = trinket.Agility,
                Intellect = trinket.Intellect,
                Spirit = trinket.Spirit,
                BuyPrice = trinket.BuyPrice,
                SellPrice = trinket.SellPrice,
                Slot = trinket.Slot,
                ImagePath = trinket.ImagePath,
            };
        }

        private async Task<ItemFullViewModel> GetMaterial(GetCurrentItemQuery request)
        {
            var material = await this.Context.Materials.FindAsync(int.Parse(request.ItemId));

            string toolName;
            string relatedMaterials;
            if (material.ToolId != null)
            {
                var tool = await this.Context.Tools.FindAsync(material.ToolId);

                toolName = tool.Name;
            }
            else
            {
                toolName = "None";
            }

            if (material.RelatedMaterials != null)
            {
                relatedMaterials = material.RelatedMaterials;
            }
            else
            {
                relatedMaterials = "None";
            }

            return new ItemFullViewModel
            {
                Id = material.Id,
                Name = material.Name,
                BuyPrice = material.BuyPrice,
                SellPrice = material.SellPrice,
                Slot = material.Slot,
                ImagePath = material.ImagePath,
                RelatedMaterials = relatedMaterials,
                IsCraftable = material.IsCraftable,
                IsDisolveable = material.IsDisolveable,
                IsRefineable = material.IsRefineable,
                FuelCount = material.FuelCount,
                MaterialType = material.Type,
                ToolName = toolName,
            };
        }

        private async Task<ItemFullViewModel> GetTool(GetCurrentItemQuery request)
        {
            var tool = await this.Context.Tools.FindAsync(int.Parse(request.ItemId));

            return new ItemFullViewModel
            {
                Id = tool.Id,
                Name = tool.Name,
                BuyPrice = tool.BuyPrice,
                SellPrice = tool.SellPrice,
                Slot = tool.Slot,
                ImagePath = tool.ImagePath,
                IsCraftable = tool.IsCraftable,
                Durability = tool.Durability,
            };
        }

        private async Task<ItemFullViewModel> GetLootBox(GetCurrentItemQuery request)
        {
            var treasure = await this.Context.LootBoxes.FindAsync(int.Parse(request.ItemId));

            return new ItemFullViewModel
            {
                Id = treasure.Id,
                Name = treasure.Name,
                Rarity = treasure.Type,
                Slot = treasure.Slot,
                ImagePath = treasure.ImagePath,
            };
        }

        private async Task<ItemFullViewModel> GetLootKey(GetCurrentItemQuery request)
        {
            var treasureKey = await this.Context.LootKeys.FindAsync(int.Parse(request.ItemId));

            return new ItemFullViewModel
            {
                Id = treasureKey.Id,
                Name = treasureKey.Name,
                Rarity = treasureKey.Type,
                Slot = treasureKey.Slot,
                ImagePath = treasureKey.ImagePath,
            };
        }
    }
}
