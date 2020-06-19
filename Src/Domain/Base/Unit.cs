namespace Domain.Base
{
    using global::Domain.Contracts.Units;

    public abstract class Unit : IUnit
    {
        public Unit()
        {
            this.Level = 1;
        }
        public virtual string Name { get; set; }

        public virtual string Type { get; set; }

        public virtual int Level { get; set; }

        public virtual double MaxHP { get; set; }

        public virtual double CurrentHP { get; set; }

        public virtual double HealthRegen { get; set; }

        public virtual double CurrentHealthRegen { get; set; }

        public virtual double MaxMana { get; set; }

        public virtual double CurrentMana { get; set; }

        public virtual double ManaRegen { get; set; }

        public virtual double CurrentManaRegen { get; set; }

        public virtual double AttackPower { get; set; }

        public virtual double CurrentAttackPower { get; set; }

        public virtual double MagicPower { get; set; }

        public virtual double CurrentMagicPower { get; set; }

        public virtual double ArmorValue { get; set; }

        public virtual double CurrentArmorValue { get; set; }

        public virtual double ResistanceValue { get; set; }

        public virtual double CurrentResistanceValue { get; set; }

        public virtual double CritChance { get; set; }

        public virtual double CurrentCritChance { get; set; }

        public virtual bool IsStunned { get; set; }

        public virtual bool IsSilenced { get; set; }

        public virtual bool IsBlinded { get; set; }

        public virtual bool IsConfused { get; set; }

        public virtual bool IsProvoked { get; set; }

        public virtual string ImagePath { get; set; }

        public virtual int CoinAmount { get; set; }
    }
}
