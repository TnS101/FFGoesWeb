namespace Application.GameCQ.Heroes.Queries.GetFullUnitQuery
{
    using System.Collections.Generic;
    using Domain.Entities.Game.Units;

    public class UnitFullViewModel
    {
        public UnitFullViewModel()
        {
            this.Spells = new HashSet<Spell>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public double AttackPower { get; set; }

        public double CurrentAttackPower { get; set; }

        public double MagicPower { get; set; }

        public double CurrentMagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double CurrentArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double CurrentResistanceValue { get; set; }

        public int HealthRegen { get; set; }

        public int CurrentHealthRegen { get; set; }

        public int ManaRegen { get; set; }

        public int CurrentManaRegen { get; set; }

        public double CritChance { get; set; }

        public double CurrentCritChance { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public string ImagePath { get; set; }

        public int GoldAmount { get; set; }

        public int ProffesionLevel { get; set; }

        public double ProffesionXP { get; set; }

        public double ProffesionXPCap { get; set; }

        public ICollection<Spell> Spells { get; set; }
    }
}
