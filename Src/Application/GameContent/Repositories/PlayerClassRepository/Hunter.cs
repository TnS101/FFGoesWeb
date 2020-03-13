namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Hunter : FightingClass
    {
        private const string classType = "Hunter";
        private const double maxHP = 200;
        private const int healthRegen = 2;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 32;
        private const double magicPower = 12;
        private const double armorValue = 3.5;
        private const double ressistanceValue = 2.5;
        private const double critChance = 6;

        public Hunter()
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
