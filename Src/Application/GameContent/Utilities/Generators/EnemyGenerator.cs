namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Base;
    using Domain.Entities.Game.Units;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;

    public class EnemyGenerator
    {
        public EnemyGenerator()
        {
        }

        public async Task<Unit> Generate(int playerLevel, IFFDbContext context)
        {
            Monster monster = new Monster { Type = "Enemy", Level = playerLevel };

            StatIncrement statIncrement = new StatIncrement();

            var rng = new Random();

            int enemyNumber = rng.Next(0, 26);

            int monsterId = 0;

            if (enemyNumber >= 0 && enemyNumber <= 5) // Beast
            {
                monsterId = 1;
            }

            if (enemyNumber >= 6 && enemyNumber <= 10) // Reptile
            {
                monsterId = 2;
            }

            if (enemyNumber >= 11 && enemyNumber <= 14) // Zombie
            {
                monsterId = 3;
            }

            if (enemyNumber >= 15 && enemyNumber <= 18) // Skeleton
            {
                monsterId = 4;
            }

            if (enemyNumber == 19 || enemyNumber == 20) // Wyrm
            {
                monsterId = 5;
            }

            if (enemyNumber == 21 || enemyNumber == 22) // Giant
            {
                monsterId = 6;
            }

            if (enemyNumber == 23 || enemyNumber == 24) // Gryphon
            {
                monsterId = 7;
            }

            if (enemyNumber == 25) // Saint
            {
                monsterId = 8;
            }

            if (enemyNumber == 26) // Demon
            {
                monsterId = 9;
            }

            var baseMonster = await context.Monsters.FindAsync(monsterId);

            statIncrement.MonsterIncrement(baseMonster, monster);

            monster.Name = monster.ClassType;

            return await this.RarityRng(monster, context);
        }

        private async Task<Monster> RarityRng(Monster monster, IFFDbContext context)
        {
            var rng = new Random();

            int number = rng.Next(1, 11);

            var monsterRarity = new MonsterRarity();

            if (number == 1)
            {
                monsterRarity = context.MonsterRarities.FirstOrDefault(mr => mr.MonsterName == monster.Name && mr.Rarity == "Heroic");
            }
            else if (number == 2 || number == 3 || number == 4)
            {
                monsterRarity = context.MonsterRarities.FirstOrDefault(mr => mr.MonsterName == monster.Name && mr.Rarity == "Rare");
            }
            else
            {
                return monster;
            }

            monster.ImageURL = monsterRarity.ImageURL;
            monster.MaxHP += monsterRarity.StatAmplifier * monster.MaxHP;
            monster.AttackPower += monsterRarity.StatAmplifier * monster.AttackPower;
            monster.MagicPower += monsterRarity.StatAmplifier * monster.MagicPower;
            monster.ArmorValue += monsterRarity.StatAmplifier * monster.ArmorValue;
            monster.CurrentHP += monsterRarity.StatAmplifier * monster.CurrentHP;
            monster.CurrentAttackPower += monsterRarity.StatAmplifier * monster.CurrentAttackPower;
            monster.CurrentMagicPower += monsterRarity.StatAmplifier * monster.CurrentMagicPower;
            monster.CurrentArmorValue += monsterRarity.StatAmplifier * monster.CurrentArmorValue;

            return monster;
        }
    }
}
