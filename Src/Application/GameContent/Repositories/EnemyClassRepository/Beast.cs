namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Beast : FightingClass
    {
        private const string classType = "Beast";
        private const double maxHP = 100;
        private const int healthRegen = 2;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 11;
        private const double magicPower = 5;
        private const double armorValue = 4.5;
        private const double ressistanceValue = 3;
        private const double critChance = 3;

        public Beast()
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
