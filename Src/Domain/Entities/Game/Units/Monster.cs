namespace Domain.Entities.Game.Units
{
    using Domain.Contracts.Units;
    using Domain.Entities.Game.Units.OneToOne;
    using System.Collections.Generic;

    public class Monster : IUnit
    {
        public Monster()
        {
            this.Type = "Monster";
            this.Spells = new HashSet<Spell>();
        }

        public int Id { get; set; }

        public int? MonsterRarityId { get; set; }

        public MonsterRarity MonsterRarity { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string ImagePath { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double HealthRegen { get; set; }

        public double CurrentHealthRegen { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public double ManaRegen { get; set; }

        public double CurrentManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double CurrentAttackPower { get; set; }

        public double MagicPower { get; set; }

        public double CurrentMagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double CurrentArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public double CurrentResistanceValue { get; set; }

        public double CritChance { get; set; }

        public double CurrentCritChance { get; set; }

        public bool IsConfused { get; set; }

        public bool IsProvoked { get; set; }

        public bool IsSilenced { get; set; }

        public bool IsStunned { get; set; }

        public bool IsBlinded { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int CoinAmount { get; set; }

        public ICollection<Spell> Spells { get; set; }

        public int ConfusionDuration { get; set; }

        public int ProvokeDuration { get; set; }

        public int SilenceDuration { get; set; }

        public int StunDuration { get; set; }

        public int BlindDuration { get; set; }
    }
}
