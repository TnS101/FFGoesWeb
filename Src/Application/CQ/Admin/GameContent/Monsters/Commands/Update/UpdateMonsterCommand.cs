namespace Application.CQ.Admin.GameContent.Monsters.Commands.Update
{
    using MediatR;

    public class UpdateMonsterCommand : IRequest<string>
    {
        public int MonsterId { get; set; }

        public string Name { get; set; }

        public double MaxHP { get; set; }

        public double MaxMana { get; set; }

        public double HealthRegen { get; set; }

        public double ManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double CritChance { get; set; }

        public string Zone { get; set; }

        public string Description { get; set; }
    }
}
