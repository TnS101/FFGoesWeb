namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Beast : FightingClass
    {
        private const string ClassTypeValue = "Beast";
        private const double MaxHPValue = 100;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 11;
        private const double MagicPowerValue = 5;
        private const double ArmorValueValue = 4.5;
        private const double RessistanceValueValue = 3;
        private const double CritChanceValue = 3;

        public Beast()
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
