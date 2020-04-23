namespace Application.CQ.Admin.GameContent.Items.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.Common.StringProcessing.ImagePaths;
    using Domain.Entities.Game.Items;
    using global::Common;
    using MediatR;

    public class CreateItemCommandHandler : BaseHandler, IRequestHandler<CreateItemCommand, string>
    {
        private readonly ImagePath imagePath;

        public CreateItemCommandHandler(IFFDbContext context)
            : base(context)
        {
            this.imagePath = new ImagePath();
        }

        public async Task<string> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            string id;

            if (request.Slot == "Weapon")
            {
               id = await this.CreateWeapon(request, cancellationToken);
            }
            else if (request.Slot == "Trinket")
            {
               id = await this.CreateTrinket(request, cancellationToken);
            }
            else if (request.Slot == "Material")
            {
               var result = await this.CreateMaterial(request, cancellationToken);

               id = result.ToString();
            }
            else if (request.Slot == "Treasure")
            {
                var result = await this.CreateTreasure(request, cancellationToken);

                id = result.ToString();
            }
            else if (request.Slot == "Treasure Key")
            {
                var result = await this.CreateTreasureKey(request, cancellationToken);

                id = result.ToString();
            }
            else if (request.Slot == "Tool")
            {
                var result = await this.CreateTool(request, cancellationToken);

                id = result.ToString();
            }
            else
            {
                id = await this.CreateArmor(request, cancellationToken);
            }

            return string.Format(GConst.AdminItemCommandRedirectId, request.Slot, id);
        }

        private async Task<string> CreateWeapon(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var weapon = new Weapon
            {
                Name = request.Name,
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                AttackPower = request.AttackPower,
                SellPrice = request.SellPrice,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            this.Context.Weapons.Add(weapon);

            await this.Context.SaveChangesAsync(cancellationToken);

            return weapon.Id;
        }

        private async Task<string> CreateArmor(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var armor = new Armor
            {
                Name = request.Name,
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                ArmorValue = request.ArmorValue,
                ResistanceValue = request.ResistanceValue,
                Slot = request.Slot,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            this.Context.Armors.Add(armor);

            await this.Context.SaveChangesAsync(cancellationToken);

            return armor.Id;
        }

        private async Task<string> CreateTrinket(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var trinket = new Trinket
            {
                Name = request.Name,
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            this.Context.Trinkets.Add(trinket);

            await this.Context.SaveChangesAsync(cancellationToken);

            return trinket.Id;
        }

        private async Task<int> CreateMaterial(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var material = new Material
            {
                Name = request.Name,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                FuelCount = request.FuelCount,
                RelatedMaterials = request.RelatedMaterials,
                Type = request.MaterialType,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            if (request.MaterialDiversity == "craftable")
            {
                material.IsCraftable = true;
                material.ToolId = request.ToolId;
            }
            else if (request.MaterialDiversity == "disolveable")
            {
                material.IsDisolveable = true;
                material.ToolId = request.ToolId;
            }
            else if (request.MaterialDiversity == "refineable")
            {
                material.IsRefineable = true;
                material.ToolId = request.ToolId;
            }

            this.Context.Materials.Add(material);

            await this.Context.SaveChangesAsync(cancellationToken);

            return material.Id;
        }

        private async Task<int> CreateTreasure(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var treasure = new Treasure
            {
                Name = request.Name,
                Rarity = request.Rarity,
                Reward = request.Reward,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            this.Context.Treasures.Add(treasure);

            await this.Context.SaveChangesAsync(cancellationToken);

            return treasure.Id;
        }

        private async Task<int> CreateTreasureKey(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var treasureKey = new TreasureKey
            {
                Name = request.Name,
                Rarity = request.Rarity,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            this.Context.TreasureKeys.Add(treasureKey);

            await this.Context.SaveChangesAsync(cancellationToken);

            return treasureKey.Id;
        }

        private async Task<int> CreateTool(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var tool = new Tool
            {
                Name = request.Name,
                BuyPrice = request.BuyPrice,
                Durability = request.Durability,
                ImagePath = this.imagePath.Process(new string[] { "Item", request.Slot, request.Name }),
            };

            if (request.MaterialDiversity == "craftable")
            {
                tool.IsCraftable = true;
            }

            this.Context.Tools.Add(tool);

            await this.Context.SaveChangesAsync(cancellationToken);

            return tool.Id;
        }
    }
}
