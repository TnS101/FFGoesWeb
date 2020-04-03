namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Entities.Game.Units;

    public class EnemyGenerator
    {
        public EnemyGenerator()
        {
        }

        public async Task<Monster> Generate(int playerLevel, IFFDbContext context, string zoneName)
        {
            Monster monster = new Monster { Level = playerLevel };

            StatIncrement statIncrement = new StatIncrement();

            var rng = new Random();

            int enemyNumber = rng.Next(0, 26);

            int monsterId = 0;

            if (zoneName == "World")
            {
                monsterId = this.WorldMonsterId(enemyNumber);
            }
            else if (zoneName == "Tainted Forest")
            {
                
            }
            else if (zoneName == "Endless Mine")
            {
                
            }
            else if (zoneName == "The Wilderness")
            {
                
            }
            else if (zoneName == "Vile City")
            {
                
            }
            else if (zoneName == "Magical Flower Shop")
            {
                
            }
            else if (zoneName == "The Core")
            {
                
            }
            else if (zoneName == "Rocky Basin")
            {
                
            }
            else if (zoneName == "Happy Garden")
            {
                
            }
            else if (zoneName == "Scrap Terminal")
            {
                
            }


            var baseMonster = await context.Monsters.FindAsync(monsterId);

            statIncrement.MonsterIncrement(baseMonster, monster);

            return this.RarityRng(monster, context);
        }

        private Monster RarityRng(Monster monster, IFFDbContext context)
        {
            var rng = new Random();

            int number = rng.Next(1, 11);

            var monsterRarity = new MonsterRarity();

            double statAmplifier = 1;

            if (number == 1)
            {
                monsterRarity = context.MonstersRarities.FirstOrDefault(mr => mr.MonsterName == monster.Name && mr.Rarity == "Heroic");
                statAmplifier = monsterRarity.StatAmplifier;
            }
            else if (number == 2 || number == 3 || number == 4)
            {
                monsterRarity = context.MonstersRarities.FirstOrDefault(mr => mr.MonsterName == monster.Name && mr.Rarity == "Rare");
                statAmplifier = monsterRarity.StatAmplifier;
            }

            monster.ImageURL = monsterRarity.ImageURL;
            monster.MaxHP += monsterRarity.StatAmplifier * monster.MaxHP;
            monster.AttackPower += statAmplifier * monster.AttackPower;
            monster.MagicPower += statAmplifier * monster.MagicPower;
            monster.ArmorValue += statAmplifier * monster.ArmorValue;
            monster.CurrentHP += statAmplifier * monster.CurrentHP;
            monster.CurrentAttackPower += statAmplifier * monster.CurrentAttackPower;
            monster.CurrentMagicPower += statAmplifier * monster.CurrentMagicPower;
            monster.CurrentArmorValue += statAmplifier * monster.CurrentArmorValue;

            return monster;
        }

        private int WorldMonsterId(int enemyNumber)
        {
            if (enemyNumber >= 0 && enemyNumber <= 5) // Beast
            {
                return 9;
            }

            if (enemyNumber >= 6 && enemyNumber <= 10) // Reptile
            {
                return 8;
            }

            if (enemyNumber >= 11 && enemyNumber <= 14) // Zombie
            {
                return 7;
            }

            if (enemyNumber >= 15 && enemyNumber <= 18) // Skeleton
            {
                return 6;
            }

            if (enemyNumber == 19 || enemyNumber == 20) // Wyrm
            {
                return 5;
            }

            if (enemyNumber == 21 || enemyNumber == 22) // Giant
            {
                return 4;
            }

            if (enemyNumber == 23 || enemyNumber == 24) // Gryphon
            {
                return 3;
            }

            if (enemyNumber == 25) // Saint
            {
                return 2;
            }

            if (enemyNumber == 26) // Demon
            {
                return 1;
            }

            return 9;
        }
    }
}
