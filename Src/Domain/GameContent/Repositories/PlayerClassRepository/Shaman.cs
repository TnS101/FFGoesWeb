namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Repositories.PlayerClassRepository
{
    public class Shaman : FightingClass
    {
        private const string classType = "Shaman";
        private const double maxHP = 180;
        private const int healthRegen = 2;
        private const double maxMana = 115;
        private const int manaRegen = 12;
        private const double attackPower = 20;
        private const double magicPower = 20;
        private const double armorValue = 3;
        private const double ressistanceValue = 5;
        private const double critChance = 3;

        public Shaman()
        {
        }

        public override string ClassType => classType;
        public override double MaxHP => maxHP;
        public override int HealthRegen => healthRegen;
        public override double MaxMana => maxMana;
        public override int ManaRegen => manaRegen;
        public override double AttackPower => attackPower;
        public override double ArmorValue => armorValue;
        public override double RessistanceValue => ressistanceValue;
        public override double MagicPower => magicPower;
        public override double CritChance => critChance;
    }
}
