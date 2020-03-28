namespace Domain.Entities.Game.Units
{
    using Domain.Base;
    using Domain.Contracts.FightingClass;
    using System.Collections.Generic;

    public class FightingClass : IFightingClass
    {
        public int Id { get; set; }

        public string ClassType { get; set; }

        public double MaxHP { get; set; }

        public int HealthRegen { get; set; }

        public double MaxMana { get; set; }

        public int ManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double ArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public double MagicPower { get; set; }

        public double CritChance { get; set; }

        public string Description { get; set; }

        public string IconURL { get; set; }

        public string ImageURL { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
