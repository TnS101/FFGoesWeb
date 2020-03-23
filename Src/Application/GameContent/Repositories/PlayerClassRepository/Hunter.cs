namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Hunter : FightingClass
    {
        private const string ClassTypeValue = "Hunter";
        private const double MaxHPValue = 200;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 32;
        private const double MagicPowerValue = 12;
        private const double ArmorValueValue = 3.5;
        private const double RessistanceValueValue = 2.5;
        private const double CritChanceValue = 6;

        public Hunter()
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
