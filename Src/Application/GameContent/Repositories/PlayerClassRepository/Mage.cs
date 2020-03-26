namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Mage : FightingClass
    {
        private const string ClassTypeValue = "Mage";
        private const double MaxHPValue = 200;
        private const int HealthRegenValue = 3;
        private const double MaxManaValue = 150;
        private const int ManaRegenValue = 10;
        private const double AttackPowerValue = 18;
        private const double MagicPowerValue = 30;
        private const double ArmorValueValue = 2;
        private const double RessistanceValueValue = 6;
        private const double CritChanceValue = 2;

        public Mage()
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
