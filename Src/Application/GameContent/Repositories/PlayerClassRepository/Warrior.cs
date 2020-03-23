namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Warrior : FightingClass
    {
        private const string ClassTypeValue = "Warrior";
        private const double MaxHPValue = 260;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 28;
        private const double MagicPowerValue = 13;
        private const double ArmorValueValue = 5;
        private const double RessistanceValueValue = 3;
        private const double CritChanceValue = 3;

        public Warrior()
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
