namespace FinalFantasyTryoutGoesWeb.Application.GameContent
{
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Contracts;

    public abstract class FightingClass : IFightingClass
    {
        public FightingClass()
        {
        }

        public virtual string ClassType { get; }
        public virtual double MaxHP { get; }
        public virtual int HealthRegen { get; }
        public virtual double MaxMana { get; }
        public virtual int ManaRegen { get; }
        public virtual double AttackPower { get; }
        public virtual double ArmorValue { get; }
        public virtual double RessistanceValue { get; }
        public virtual double MagicPower { get; }
        public virtual double CritChance { get; }
    }
}
