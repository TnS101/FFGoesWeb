namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Priest : FightingClass
    {
        private const string ClassTypeValue = "Priest";
        private const double MaxHPValue = 170;
        private const int HealthRegenValue = 5;
        private const double MaxManaValue = 180;
        private const int ManaRegenValue = 10;
        private const double AttackPowerValue = 15;
        private const double MagicPowerValue = 32;
        private const double ArmorValueValue = 2.8;
        private const double RessistanceValueValue = 5.3;
        private const double CritChanceValue = 2;

        public Priest()
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
