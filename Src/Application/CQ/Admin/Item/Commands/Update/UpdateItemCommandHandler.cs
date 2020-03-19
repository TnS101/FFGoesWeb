namespace Application.CQ.Admin.Item.Commands.Update
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IFFDbContext context;
        public UpdateItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var oldItem = await this.context.Items.FindAsync(request.Id);

            var newName = request.NewName;

            var newLevel = request.NewLevel;

            var newClassType = request.NewClassType;

            var newStamina = request.NewStamina;

            var newStrength = request.NewStrength;

            var newAgility = request.NewAgility;

            var newIntellect = request.NewIntellect;

            var newSpirit = request.NewSpirit;

            var newAttackPower = request.NewAttackPower;

            var newArmorValue = request.NewArmorValue;

            var newRessistanceValue = request.NewRessistanceValue;

            var newSlot = request.NewSlot;

            if (string.IsNullOrWhiteSpace(newName))
            {
                newName = oldItem.Name;
            }
            if (newLevel == 0)
            {
                newLevel = oldItem.Level;
            }
            if (string.IsNullOrWhiteSpace(newClassType))
            {
                newClassType = oldItem.ClassType;
            }
            if (newStamina == 0)
            {
                newStamina = oldItem.Stamina;
            }
            if (newStrength == 0)
            {
                newStrength = oldItem.Strength;
            }
            if (newAgility == 0)
            {
                newAgility = oldItem.Agility;
            }
            if (newIntellect == 0)
            {
                newIntellect = oldItem.Intellect;
            }
            if (newSpirit == 0)
            {
                newSpirit = oldItem.Spirit;
            }
            if (newAttackPower == 0)
            {
                newAttackPower = oldItem.AttackPower;
            }
            if (newArmorValue == 0)
            {
                newArmorValue = oldItem.ArmorValue;
            }
            if (newRessistanceValue == 0)
            {
                newRessistanceValue = oldItem.ArmorValue;
            }
            if (string.IsNullOrWhiteSpace(newSlot))
            {
                newSlot = oldItem.Slot;
            }

            this.SlotCheck(newAttackPower,newArmorValue,newRessistanceValue,newSlot);

            await this.context.Items.AddAsync(new FinalFantasyTryoutGoesWeb.Domain.Entities.Game.Item 
            {
                Name = newName,
                Level = newLevel,
                ClassType = newClassType,
                Stamina = newStamina,
                Strength = newStrength,
                Agility = newAgility,
                Intellect = newIntellect,
                Spirit = newSpirit,
                AttackPower = newAttackPower,
                ArmorValue = newArmorValue,
                Slot = newSlot
            });

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void SlotCheck(double newAttackPower, double newArmorValue, double newRessistanceValue, string newSlot) 
        {
            if (newSlot == "Weapon")
            {
                newArmorValue = 0;
                newRessistanceValue = 0;
            }
            if (newSlot == "Trinket")
            {
                newArmorValue = 0;
                newRessistanceValue = 0;
                newAttackPower = 0;
            }
            else
            {
                newAttackPower = 0;
            }
        }
    }
}
