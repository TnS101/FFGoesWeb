namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Shaman : FightingClass
    {
        private const string ClassTypeValue = "Shaman";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 115;
        private const int ManaRegenValue = 12;
        private const double AttackPowerValue = 20;
        private const double MagicPowerValue = 20;
        private const double ArmorValueValue = 3;
        private const double RessistanceValueValue = 5;
        private const double CritChanceValue = 3;

        public Shaman()
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
