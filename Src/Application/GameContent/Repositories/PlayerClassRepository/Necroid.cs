namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Necroid : FightingClass
    {
        private const string ClassTypeValue = "Necroid";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 4;
        private const double MaxManaValue = 140;
        private const int ManaRegenValue = 10;
        private const double AttackPowerValue = 15;
        private const double MagicPowerValue = 30;
        private const double ArmorValueValue = 2.5;
        private const double RessistanceValueValue = 8;
        private const double CritChanceValue = 2;

        public Necroid()
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
