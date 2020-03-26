namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Rogue : FightingClass
    {
        private const string ClassTypeValue = "Rogue";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 3;
        private const double MaxManaValue = 100;
        private const int ManaRegenValue = 5;
        private const double AttackPowerValue = 35;
        private const double MagicPowerValue = 8;
        private const double ArmorValueValue = 2.5;
        private const double RessistanceValueValue = 2;
        private const double CritChanceValue = 8;

        public Rogue()
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
