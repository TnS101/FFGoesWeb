namespace Application.CQ.Admin.GameContent.Monsters.Commands.Update
{
    using MediatR;

    public class UpdateMonsterCommand : IRequest<string>
    {
        public int MonsterId { get; set; }

        public string NewName { get; set; }

        public double NewMaxHP { get; set; }

        public double NewMaxMana { get; set; }

        public double NewHealthRegen { get; set; }

        public double NewManaRegen { get; set; }

        public double NewAttackPower { get; set; }

        public double NewMagicPower { get; set; }

        public double NewArmorValue { get; set; }

        public double NewResistanceValue { get; set; }

        public double NewCritChance { get; set; }

        public string NewDescription { get; set; }
    }
}
