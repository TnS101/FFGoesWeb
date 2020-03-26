namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Shaman : FightingClass
    {
        private const string ClassTypeValue = "Shaman";
        private const double MaxHPValue = 180;
        private const int HealthRegenValue = 2;
        private const double MaxManaValue = 115;
        private const int ManaRegenValue = 12;
        private const double AttackPowerValue = 20;
        private const double MagicPowerValue = 20;
        private const double ArmorValueValue = 3;
        private const double RessistanceValueValue = 5;
        private const double CritChanceValue = 3;

        public Shaman()
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
