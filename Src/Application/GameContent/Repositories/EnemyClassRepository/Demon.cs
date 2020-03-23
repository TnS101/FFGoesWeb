namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Demon : FightingClass
    {
        private const string ClassTypeValue = "Demon";
        private const double MaxHPValue = 150;
        private const int HealthRegenValue = 4;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 22;
        private const double MagicPowerValue = 5;
        private const double ArmorValueValue = 5;
        private const double RessistanceValueValue = 1;
        private const double CritChanceValue = 5;

        public Demon()
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
