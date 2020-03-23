namespace Application.CQ.Admin.Item.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
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
            var item = await this.context.Items.FindAsync(request.Id);

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
                newName = item.Name;
            }

            if (newLevel == 0)
            {
                newLevel = item.Level;
            }

            if (string.IsNullOrWhiteSpace(newClassType))
            {
                newClassType = item.ClassType;
            }

            if (newStamina == 0)
            {
                newStamina = item.Stamina;
            }

            if (newStrength == 0)
            {
                newStrength = item.Strength;
            }

            if (newAgility == 0)
            {
                newAgility = item.Agility;
            }

            if (newIntellect == 0)
            {
                newIntellect = item.Intellect;
            }

            if (newSpirit == 0)
            {
                newSpirit = item.Spirit;
            }

            if (newAttackPower == 0)
            {
                newAttackPower = item.AttackPower;
            }

            if (newArmorValue == 0)
            {
                newArmorValue = item.ArmorValue;
            }

            if (newRessistanceValue == 0)
            {
                newRessistanceValue = item.ArmorValue;
            }

            if (string.IsNullOrWhiteSpace(newSlot))
            {
                newSlot = item.Slot;
            }

            this.SlotCheck(newAttackPower, newArmorValue, newRessistanceValue, newSlot);

            item.Name = newName;
            item.Level = newLevel;
            item.ClassType = newClassType;
            item.Stamina = newStamina;
            item.Strength = newStrength;
            item.Agility = newAgility;
            item.Intellect = newIntellect;
            item.Spirit = newSpirit;
            item.AttackPower = newAttackPower;
            item.ArmorValue = newArmorValue;
            item.Slot = newSlot;

            this.context.Items.Update(item);

            await this.context.SaveChangesAsync(cancellationToken);

            return "/Items";
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
