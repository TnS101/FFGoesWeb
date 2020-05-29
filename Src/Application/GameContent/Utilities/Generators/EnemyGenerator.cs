namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.OneToOne;
    using Microsoft.EntityFrameworkCore;

    public class EnemyGenerator
    {
        public async Task<Monster> Generate(int playerLevel, IFFDbContext context, string zoneName)
        {
            var rng = new Random();

            var monster = new Monster { Level = playerLevel };

            var statIncrement = new StatIncrement();

            string monsterName = this.MonsterName(zoneName, rng);

            statIncrement.MonsterIncrement(await context.Monsters.FirstOrDefaultAsync(m => m.Name == monsterName), monster);

            return await this.RarityRng(monster, context, rng);
        }

        private async Task<Monster> RarityRng(Monster monster, IFFDbContext context, Random rng)
        {
            int number = rng.Next(1, 11);

            var monsterRarity = new MonsterRarity();

            double statAmplifier = 1;

            if (number == 1)
            {
                monsterRarity = await context.MonstersRarities.FirstOrDefaultAsync(mr => mr.MonsterName == monster.Name && mr.Rarity == "Heroic");
                statAmplifier = monsterRarity.StatAmplifier;
                monster.ImagePath = monsterRarity.ImagePath.ToString();
            }
            else if (number > 1 && number < 5)
            {
                monsterRarity = await context.MonstersRarities.FirstOrDefaultAsync(mr => mr.MonsterName == monster.Name && mr.Rarity == "Rare");
                statAmplifier = monsterRarity.StatAmplifier;
                monster.ImagePath = monsterRarity.ImagePath.ToString();
            }

            monster.MaxHP += monsterRarity.StatAmplifier * monster.MaxHP;
            monster.CurrentHP += statAmplifier * monster.CurrentHP;
            monster.AttackPower += statAmplifier * monster.AttackPower;
            monster.CurrentAttackPower += statAmplifier * monster.CurrentAttackPower;
            monster.MagicPower += statAmplifier * monster.MagicPower;
            monster.CurrentMagicPower += statAmplifier * monster.CurrentMagicPower;

            return monster;
        }

        private string MonsterName(string zoneName, Random rng)
        {
            int enemyNumber = rng.Next(0, 27);

            if (zoneName == "World")
            {
                if (enemyNumber >= 0 && enemyNumber <= 5)
                {
                    return "Bear";
                }
                else if (enemyNumber >= 6 && enemyNumber <= 10)
                {
                    return "Reptile";
                }
                else if (enemyNumber >= 11 && enemyNumber <= 14)
                {
                    return "Zombie";
                }
                else if (enemyNumber >= 15 && enemyNumber <= 18)
                {
                    return "Skeleton";
                }
                else if (enemyNumber == 19 || enemyNumber == 20)
                {
                    return "Wyrm";
                }
                else if (enemyNumber == 21 || enemyNumber == 22)
                {
                    return "Giant";
                }
                else if (enemyNumber == 23 || enemyNumber == 24)
                {
                    return "Gryphon";
                }
                else if (enemyNumber == 25)
                {
                    return "Saint";
                }
                else
                {
                    return "Demon";
                }
            }

            return string.Empty;
        }
    }
}
