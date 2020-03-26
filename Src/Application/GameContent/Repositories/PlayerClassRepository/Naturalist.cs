namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Naturalist : FightingClass
    {
        private const string ClassTypeValue = "Naturalist";
        private const double MaxHPValue = 220;
        private const int HealthRegenValue = 3;
        private const double MaxManaValue = 120;
        private const int ManaRegenValue = 12;
        private const double AttackPowerValue = 15;
        private const double MagicPowerValue = 28;
        private const double ArmorValueValue = 5;
        private const double RessistanceValueValue = 2.2;
        private const double CritChanceValue = 2;

        public Naturalist()
        {
            this.ClassType = ClassTypeValue;
            this.MaxHP = MaxHPValue;
            this.HealthRegen = HealthRegenValue;
            this.MaxMana = MaxManaValue;
            this.ManaRegen = ManaRegenValue;
            this.AttackPower = AttackPowerValue;
            this.MagicPower = MagicPowerValue;
            this.ArmorValue = ArmorValueValue;
            this.RessistanceValue = RessistanceValueValue;
            this.CritChance = CritChanceValue;
        }
    }
}
