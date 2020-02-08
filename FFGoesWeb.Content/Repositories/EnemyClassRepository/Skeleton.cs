namespace FinalFantasyTryoutGoesWeb.GameContent.Repositories.EnemyClassRepository
{
    public class Skeleton : FightingClass
    {
        private const string classType = "Skeleton";
        private const double maxHP = 80;
        private const int healthRegen = 10;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 18;
        private const double magicPower = 2;
        private const double armorValue = 0.5;
        private const double ressistanceValue = 1;
        private const double critChance = 8;

        public Skeleton()
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
