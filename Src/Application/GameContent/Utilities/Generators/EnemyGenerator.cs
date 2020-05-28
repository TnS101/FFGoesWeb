namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.OneToOne;
    using Microsoft.EntityFrameworkCore;

    public class EnemyGenerator
    {
        private readonly Random rng;

        public EnemyGenerator()
        {
            this.rng = new Random();
        }

        public async Task<Monster> Generate(int playerLevel, IFFDbContext context, string zoneName)
        {
            var monster = new Monster { Level = playerLevel };

            var statIncrement = new StatIncrement();

            int monsterId = 0;

            if (zoneName == "World")
            {
                monsterId = this.WorldMonsterId();
            }

            // else if (zoneName == "Tainted Forest")
            // {
            // }
            // else if (zoneName == "Endless Mine")
            // {
            // }
            // else if (zoneName == "The Wilderness")
            // {
            // }
            // else if (zoneName == "Vile City")
            // {
            // }
            // else if (zoneName == "Magical Flower Shop")
            // {
            // }
            // else if (zoneName == "The Core")
            // {
            // }
            // else if (zoneName == "Rocky Basin")
            // {
            // }
            // else if (zoneName == "Happy Garden")
            // {
            // }
            // else if (zoneName == "Scrap Terminal")
            // {
            // }

            statIncrement.MonsterIncrement(await context.Monsters.FindAsync(monsterId), monster);

            return await this.RarityRng(monster, context);
        }

        private async Task<Monster> RarityRng(Monster monster, IFFDbContext context)
        {
            int number = this.rng.Next(1, 11);

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

        private int WorldMonsterId()
        {
            int enemyNumber = this.rng.Next(0, 27);

            if (enemyNumber >= 0 && enemyNumber <= 5) // Bear
            {
                return 9;
            }
            else if (enemyNumber >= 6 && enemyNumber <= 10) // Reptile
            {
                return 8;
            }
            else if (enemyNumber >= 11 && enemyNumber <= 14) // Zombie
            {
                return 7;
            }
            else if (enemyNumber >= 15 && enemyNumber <= 18) // Skeleton
            {
                return 6;
            }
            else if (enemyNumber == 19 || enemyNumber == 20) // Wyrm
            {
                return 5;
            }
            else if (enemyNumber == 21 || enemyNumber == 22) // Giant
            {
                return 4;
            }
            else if (enemyNumber == 23 || enemyNumber == 24) // Gryphon
            {
                return 3;
            }
            else if (enemyNumber == 25) // Saint
            {
                return 2;
            }
            else // Demon
            {
                return 1;
            }
        }
    }
}
