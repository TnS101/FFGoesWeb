namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Demon : FightingClass
    {
        private const string ClassTypeValue = "Demon";
        private const double MaxHPValue = 150;
        private const int HealthRegenValue = 4;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 22;
        private const double MagicPowerValue = 5;
        private const double ArmorValueValue = 5;
        private const double RessistanceValueValue = 1;
        private const double CritChanceValue = 5;

        public Demon()
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
