namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Paladin : FightingClass
    {
        private const string ClassTypeValue = "Paladin";
        private const double MaxHPValue = 220;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 110;
        private const int ManaRegenValue = 6;
        private const double AttackPowerValue = 22;
        private const double MagicPowerValue = 18;
        private const double ArmorValueValue = 4;
        private const double RessistanceValueValue = 5;
        private const double CritChanceValue = 3;

        public Paladin()
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
