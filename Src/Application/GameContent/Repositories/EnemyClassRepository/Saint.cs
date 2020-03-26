namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Saint : FightingClass
    {
        private const string ClassTypeValue = "Saint";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 5;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 10;
        private const double MagicPowerValue = 22;
        private const double ArmorValueValue = 3;
        private const double RessistanceValueValue = 8;
        private const double CritChanceValue = 8;

        public Saint()
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
