using FinalFantasyTryoutGoesWeb.Domain.GameContent;

namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemyClassRepository
{
    public class Demon : FightingClass
    {
        private const string classType = "Demon";
        private const double maxHP = 150;
        private const int healthRegen = 4;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 22;
        private const double magicPower = 5;
        private const double armorValue = 5;
        private const double ressistanceValue = 1;
        private const double critChance = 5;

        public Demon()
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
