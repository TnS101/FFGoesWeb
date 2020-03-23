namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Naturalist : FightingClass
    {
        private const string ClassTypeValue = "Naturalist";
        private const double MaxHPValue = 220;
        private const int HealthRegenValue = 3;
        private const double MaxManaValue = 120;
        private const int ManaRegenValue = 12;
        private const double AttackPowerValue = 15;
        private const double MagicPowerValue = 28;
        private const double ArmorValueValue = 5;
        private const double RessistanceValueValue = 2.2;
        private const double CritChanceValue = 2;

        public Naturalist()
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
