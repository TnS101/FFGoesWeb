namespace Application.GameCQ.Battles.Queries.GetBattleUnitsQuery
{
    using System.Collections.Generic;
    using Application.GameCQ.Spells.Queries.GetPersonalSpellsQuery;

    public class BattleUnitViewModel
    {
        public BattleUnitViewModel()
        {
            this.Spells = new HashSet<SpellMinViewModel>();
        }

        public string Name { get; set; }

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

        public string ImagePath { get; set; }

        public ICollection<SpellMinViewModel> Spells { get; set; }
    }
}
