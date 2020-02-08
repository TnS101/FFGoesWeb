namespace FinalFantasyTryoutGoesWeb.GameContent.Repositories.EnemyClassRepository
{
    public class Reptile : FightingClass
    {
        private const string classType = "Reptile";
        private const double maxHP = 70;
        private const int healthRegen = 1;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 14;
        private const double magicPower = 5;
        private const double armorValue = 3;
        private const double ressistanceValue = 3;
        private const double critChance = 5;

        public Reptile()
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
