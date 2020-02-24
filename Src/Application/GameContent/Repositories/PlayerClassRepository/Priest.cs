using FinalFantasyTryoutGoesWeb.Domain.GameContent;

namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Priest : FightingClass
    {
        private const string classType = "Priest";
        private const double maxHP = 170;
        private const int healthRegen = 5;
        private const double maxMana = 180;
        private const int manaRegen = 10;
        private const double attackPower = 15;
        private const double magicPower = 32;
        private const double armorValue = 2.8;
        private const double ressistanceValue = 5.3;
        private const double critChance = 2;

        public Priest()
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
