using FinalFantasyTryoutGoesWeb.Domain.GameContent;

namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerClassRepository
{
    public class Rogue : FightingClass
    {
        private const string classType = "Rogue";
        private const double maxHP = 180;
        private const int healthRegen = 3;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 35;
        private const double magicPower = 8;
        private const double armorValue = 2.5;
        private const double ressistanceValue = 2;
        private const double critChance = 8;

        public Rogue()
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
