namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Paladin : FightingClass
    {
        private const string ClassTypeValue = "Paladin";
        private const double MaxHPValue = 220;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 110;
        private const int ManaRegenValue = 6;
        private const double AttackPowerValue = 22;
        private const double MagicPowerValue = 18;
        private const double ArmorValueValue = 4;
        private const double RessistanceValueValue = 5;
        private const double CritChanceValue = 3;

        public Paladin()
        {
        }

        public override string ClassType => ClassTypeValue;

        public override double MaxHP => MaxHPValue;

        public override int HealthRegen => HealthRegenValue;

        public override double MaxMana => MaxManaValue;

        public override int ManaRegen => ManaRegenValue;

        public override double AttackPower => AttackPowerValue;

        public override double ArmorValue => ArmorValueValue;

        public override double RessistanceValue => RessistanceValueValue;

        public override double MagicPower => MagicPowerValue;

        public override double CritChance => CritChanceValue;
    }
}
