namespace Application.CQ.Admin.GameContent.Items.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items;
    using global::Common;
    using MediatR;

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, string>
    {
        private readonly IFFDbContext context;

        public CreateItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                await this.CreateWeapon(request);
            }
            else if (request.Slot == "Trinket")
            {
                await this.CreateTrinket(request);
            }
            else if (request.Slot == "Material")
            {
                await this.CreateMaterial(request);
            }
            else if (request.Slot == "Treasure")
            {
                await this.CreateTreasure(request);
            }
            else if (request.Slot == "Treasure Key")
            {
                await this.CreateTreasureKey(request);
            }
            else if (request.Slot == "Tool")
            {
                await this.CreateTool(request);
            }
            else
            {
                await this.CreateArmor(request);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.CreateItemRedirect, request.Slot);
        }

        private async Task CreateWeapon(CreateItemCommand request)
        {
            await this.context.Weapons.AddAsync(new Weapon
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
                Slot = "Weapon",
                SellPrice = request.SellPrice,
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
            });
        }

        private async Task CreateArmor(CreateItemCommand request)
        {
            await this.context.Armors.AddAsync(new Armor
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
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
            });
        }

        private async Task CreateTrinket(CreateItemCommand request)
        {
            await this.context.Trinkets.AddAsync(new Trinket
            {
                Name = request.Name,
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                Slot = "Trinket",
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
            });
        }

        private async Task CreateMaterial(CreateItemCommand request)
        {
            var material = new Material
            {
                Name = request.Name,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                FuelCount = request.FuelCount,
                RelatedMaterials = request.RelatedMaterials,
                Type = request.MaterialType,
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
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

            await this.context.Materials.AddAsync(material);
        }

        private async Task CreateTreasure(CreateItemCommand request)
        {
            await this.context.Treasures.AddAsync(new Treasure
            {
                Name = request.Name,
                Rarity = request.Rarity,
                Reward = request.Reward,
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
            });
        }

        private async Task CreateTreasureKey(CreateItemCommand request)
        {
            await this.context.TreasureKeys.AddAsync(new TreasureKey
            {
                Name = request.Name,
                Rarity = request.Rarity,
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
            });
        }

        private async Task CreateTool(CreateItemCommand request)
        {
            var tool = new Tool
            {
                Name = request.Name,
                BuyPrice = request.BuyPrice,
                Durability = request.Durability,
                RelatedMaterials = request.RelatedMaterials,
                ImagePath = this.AppendImagePath(request.Slot, request.Name),
            };

            if (request.MaterialDiversity == "craftable")
            {
                tool.IsCraftable = true;
            }

            await this.context.Tools.AddAsync(tool);
        }

        private string AppendImagePath(string itemSlot, string itemName)
        {
            return $"/images/Items/{itemSlot}s/{itemName}.png";
        }
    }
}
