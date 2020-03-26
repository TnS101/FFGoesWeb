namespace FinalFantasyTryoutGoesWeb.Application.GameContent
{
    using FinalFantasyTryoutGoesWeb.Domain.Contracts;

    public abstract class FightingClass : IFightingClass
    {
        public FightingClass()
        {
        }

        public string ClassType { get; protected set; }

        public double MaxHP { get; protected set; }

        public int HealthRegen { get; protected set; }

        public double MaxMana { get; protected set; }

        public int ManaRegen { get; protected set; }

        public double AttackPower { get; protected set; }

        public double ArmorValue { get; protected set; }

        public double RessistanceValue { get; protected set; }

        public double MagicPower { get; protected set; }

        public double CritChance { get; protected set; }
    }
}
