namespace Application.CQ.Admin.Item.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.CQ.Admin.Items.Commands.Create;
    using Domain.Entities.Game.Items;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
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
            if (request.Type == "Weapon")
            {
                this.WeaponCreate(request);
            }
            else if (request.Type == "Trinket")
            {
                this.TrinketCreate(request);
            }
            else if (request.Type == "Material")
            {
                this.CreateMaterial(request);
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
                ImageURL = request.ImageURL,
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
                RessistanceValue = request.RessistanceValue,
                Slot = request.Slot,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImageURL = request.ImageURL,
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
                ImageURL = request.ImageURL,
            });
        }

        private void CreateMaterial(CreateItemCommand request)
        {
            this.context.Materials.Add(new Material
            {
                Name = request.Name,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                ImageURL = request.ImageURL,
            });
        }
    }
}
