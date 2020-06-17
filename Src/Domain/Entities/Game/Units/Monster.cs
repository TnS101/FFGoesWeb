namespace Domain.Entities.Game.Units
{
    using Domain.Base;
    using Domain.Entities.Game.Units.OneToOne;
    using System.Collections.Generic;

    public class Monster : Unit
    {
        public Monster()
        {
            this.Type = "Monster";
            this.Spells = new HashSet<Spell>();
        }

        public int Id { get; set; }

        public int? MonsterRarityId { get; set; }

        public MonsterRarity MonsterRarity { get; set; }

        public override string Name { get; set; }

        public override int Level { get; set; }

        public override string ImagePath { get; set; }

        public override double MaxHP { get; set; }

        public override double CurrentHP { get; set; }

        public override double HealthRegen { get; set; }

        public override double CurrentHealthRegen { get; set; }

        public override double MaxMana { get; set; }

        public override double CurrentMana { get; set; }

        public override double ManaRegen { get; set; }

        public override double CurrentManaRegen { get; set; }

        public override double AttackPower { get; set; }

        public override double CurrentAttackPower { get; set; }

        public override double MagicPower { get; set; }

        public override double CurrentMagicPower { get; set; }

        public override double ArmorValue { get; set; }

        public override double CurrentArmorValue { get; set; }

        public override double ResistanceValue { get; set; }

        public override double CurrentResistanceValue { get; set; }

        public override double CritChance { get; set; }

        public override double CurrentCritChance { get; set; }

        public override bool IsConfused { get; set; }

        public override bool IsProvoked { get; set; }

        public override bool IsSilenced { get; set; }

        public override bool IsStunned { get; set; }

        public override bool IsBlinded { get; set; }

        public string Description { get; set; }

        public override string Type { get; set; }

        public ICollection<Spell> Spells { get; set; }
    }
}
