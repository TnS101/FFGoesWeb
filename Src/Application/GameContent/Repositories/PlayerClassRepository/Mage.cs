namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Mage : FightingClass
    {
        private const string ClassTypeValue = "Mage";
        private const double MaxHPValue = 200;
        private const int HealthRegenValue = 3;
        private const double MaxManaValue = 150;
        private const int ManaRegenValue = 10;
        private const double AttackPowerValue = 18;
        private const double MagicPowerValue = 30;
        private const double ArmorValueValue = 2;
        private const double RessistanceValueValue = 6;
        private const double CritChanceValue = 2;

        public Mage()
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
