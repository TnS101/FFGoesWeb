namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Saint : FightingClass
    {
        private const string ClassTypeValue = "Saint";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 5;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 10;
        private const double MagicPowerValue = 22;
        private const double ArmorValueValue = 3;
        private const double RessistanceValueValue = 8;
        private const double CritChanceValue = 8;

        public Saint()
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
