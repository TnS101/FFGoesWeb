namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Gryphon : FightingClass
    {
        private const string ClassTypeValue = "Gryphon";
        private const double MaxHPValue = 90;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 15;
        private const double MagicPowerValue = 5;
        private const double ArmorValueValue = 4;
        private const double RessistanceValueValue = 4;
        private const double CritChanceValue = 10;

        public Gryphon()
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
