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
