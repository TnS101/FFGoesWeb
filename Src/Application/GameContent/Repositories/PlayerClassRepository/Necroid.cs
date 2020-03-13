namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Necroid : FightingClass
    {
        private const string classType = "Necroid";
        private const double maxHP = 180;
        private const int healthRegen = 4;
        private const double maxMana = 140;
        private const int manaRegen = 10;
        private const double attackPower = 15;
        private const double magicPower = 30;
        private const double armorValue = 2.5;
        private const double ressistanceValue = 8;
        private const double critChance = 2;

        public Necroid()
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
