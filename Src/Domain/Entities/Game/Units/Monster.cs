namespace Domain.Entities.Game.Units
{

    public class Monster 
    {
        public int Id { get; set; }

        public int? MonsterRarityId { get; set; }

        public MonsterRarity MonsterRarity { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string ImageURL { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public int HealthRegen { get; set; }

        public int CurrentHealthRegen { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public int ManaRegen { get; set; }

        public int CurrentManaRegen { get; set; }

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

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
