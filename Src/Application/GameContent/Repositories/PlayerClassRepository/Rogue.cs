namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Rogue : FightingClass
    {
        private const string ClassTypeValue = "Rogue";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 3;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 35;
        private const double MagicPowerValue = 8;
        private const double ArmorValueValue = 2.5;
        private const double RessistanceValueValue = 2;
        private const double CritChanceValue = 8;

        public Rogue()
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
