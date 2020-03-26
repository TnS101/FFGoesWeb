namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Reptile : FightingClass
    {
        private const string ClassTypeValue = "Reptile";
        private const double MaxHPValue = 70;
        private const int HealthRegenValue = 1;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 14;
        private const double MagicPowerValue = 5;
        private const double ArmorValueValue = 3;
        private const double RessistanceValueValue = 3;
        private const double CritChanceValue = 5;

        public Reptile()
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
