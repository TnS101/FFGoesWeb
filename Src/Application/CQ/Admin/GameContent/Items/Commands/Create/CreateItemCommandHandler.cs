namespace Application.CQ.Admin.GameContent.Items.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Game.Items;
    using Application.Common.Interfaces;
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
                this.WeaponCreate(request);
            }
            else if (request.Slot == "Trinket")
            {
                this.TrinketCreate(request);
            }
            else if (request.Slot == "Material")
            {
                this.CreateMaterial(request);
            }
            else if (request.Slot == "Treasure")
            {
                this.CreateTreasure(request);
            }
            else if (request.Slot == "Treasure Key")
            {
                this.CreateTreasureKey(request);
            }
            else
            {
                this.ArmorCreate(request);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Items";
        }

        private void WeaponCreate(CreateItemCommand request)
        {
            this.context.Weapons.Add(new Weapon
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
                Slot = request.Slot,
                SellPrice = request.SellPrice,
                ImagePath = request.ImageURL,
            });
        }

        private void ArmorCreate(CreateItemCommand request)
        {
            this.context.Armors.Add(new Armor
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
                ImagePath = request.ImageURL,
            });
        }

        private void TrinketCreate(CreateItemCommand request)
        {
            this.context.Trinkets.Add(new Trinket
            {
                Name = request.Name,
                Level = request.Level,
                ClassType = request.ClassType,
                Stamina = request.Stamina,
                Strength = request.Strength,
                Agility = request.Agility,
                Intellect = request.Intellect,
                Spirit = request.Spirit,
                Slot = request.Slot,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImagePath = request.ImageURL,
            });
        }

        private void CreateMaterial(CreateItemCommand request)
        {
            this.context.Materials.Add(new Material
            {
                Name = request.Name,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImagePath = request.ImageURL,
            });
        }

        private void CreateTreasure(CreateItemCommand request)
        {
            this.context.Treasures.Add(new Treasure
            {
                Name = request.Name,
                Rarity = request.Rarity,
                Reward = request.Reward,
                ImagePath = request.ImageURL,
            });
        }

        private void CreateTreasureKey(CreateItemCommand request)
        {
            this.context.TreasureKeys.Add(new TreasureKey
            {
                Name = request.Name,
                Rarity = request.Rarity,
                ImagePath = request.ImageURL,
            });
        }
    }
}
