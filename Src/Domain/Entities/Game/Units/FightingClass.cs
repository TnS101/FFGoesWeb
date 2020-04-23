namespace Domain.Entities.Game.Units
{
    using Domain.Contracts.FightingClass;
    using System.Collections.Generic;

    public class FightingClass : IFightingClass
    {
        public FightingClass()
        {
            this.Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public double MaxHP { get; set; }

        public double MaxMana { get; set; }

        public double HealthRegen { get; set; }

        public double ManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double ArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double MagicPower { get; set; }

        public double CritChance { get; set; }

        public string Description { get; set; }

        public string IconPath { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Hero> Heroes { get; set; }
    }
}
