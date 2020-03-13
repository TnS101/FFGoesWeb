namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Naturalist : FightingClass
    {
        private const string classType = "Naturalist";
        private const double maxHP = 220;
        private const int healthRegen = 3;
        private const double maxMana = 120;
        private const int manaRegen = 12;
        private const double attackPower = 15;
        private const double magicPower = 28;
        private const double armorValue = 5;
        private const double ressistanceValue = 2.2;
        private const double critChance = 2;


        public Naturalist()
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
