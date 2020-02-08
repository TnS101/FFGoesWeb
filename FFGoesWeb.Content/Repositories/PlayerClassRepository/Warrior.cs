namespace FinalFantasyTryoutGoesWeb.GameContent.Repositories.PlayerClassRepository
{
    public class Warrior : FightingClass
    {
        private const string classType = "Warrior";
        private const double maxHP = 260;
        private const int healthRegen = 2;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 28;
        private const double magicPower = 13;
        private const double armorValue = 5;
        private const double ressistanceValue = 3;
        private const double critChance = 3;

        public Warrior()
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
