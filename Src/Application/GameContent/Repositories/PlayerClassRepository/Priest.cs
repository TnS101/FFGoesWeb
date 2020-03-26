namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Priest : FightingClass
    {
        private const string ClassTypeValue = "Priest";
        private const double MaxHPValue = 170;
        private const int HealthRegenValue = 5;
        private const double MaxManaValue = 180;
        private const int ManaRegenValue = 10;
        private const double AttackPowerValue = 15;
        private const double MagicPowerValue = 32;
        private const double ArmorValueValue = 2.8;
        private const double RessistanceValueValue = 5.3;
        private const double CritChanceValue = 2;

        public Priest()
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
