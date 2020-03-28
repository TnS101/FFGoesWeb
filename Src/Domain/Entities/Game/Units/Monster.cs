namespace Domain.Entities.Game.Units
{
    using Domain.Base;

    public class Monster : Unit
    {
        public override int Id { get; set; }

        public int? MonsterRarityId { get; set; }

        public MonsterRarity MonsterRarity { get; set; }

        public override string Name { get; set; }

        public override int Level { get; set; }

        public override string ImageURL { get; set; }

        public override double MaxHP { get; set; }

        public override double CurrentHP { get; set; }

        public override int HealthRegen { get; set; }

        public override int CurrentHealthRegen { get; set; }

        public override double MaxMana { get; set; }

        public override double CurrentMana { get; set; }

        public override int ManaRegen { get; set; }

        public override int CurrentManaRegen { get; set; }

        public override double AttackPower { get; set; }

        public override double CurrentAttackPower { get; set; }

        public override double MagicPower { get; set; }

        public override double CurrentMagicPower { get; set; }

        public override double ArmorValue { get; set; }

        public override double CurrentArmorValue { get; set; }

        public override double RessistanceValue { get; set; }

        public override double CurrentRessistanceValue { get; set; }

        public override double CritChance { get; set; }

        public override double CurrentCritChance { get; set; }

        public override string Description { get; set; }
    }
}
