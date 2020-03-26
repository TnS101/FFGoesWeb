namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Wyrm : FightingClass
    {
        private const string ClassTypeValue = "Wyrm";
        private const double MaxHPValue = 100;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 10;
        private const double AttackPowerValue = 12;
        private const double MagicPowerValue = 15;
        private const double ArmorValueValue = 2;
        private const double RessistanceValueValue = 5;
        private const double CritChanceValue = 5;

        public Wyrm()
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
