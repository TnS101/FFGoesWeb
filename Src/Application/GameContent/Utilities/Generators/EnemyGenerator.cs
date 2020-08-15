namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Linq;
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

            var monsters = await context.Monsters.Where(m => m.Zone == zoneName).ToArrayAsync();

            statIncrement.MonsterIncrement(monsters[rng.Next(monsters.Length)], monster);

            return await this.RarityRng(monster, context, rng);
        }

        private async Task<Monster> RarityRng(Monster monster, IFFDbContext context, Random rng)
        {
            int number = rng.Next(11);

            var monsterRarity = new MonsterRarity();

            double statAmplifier = 1;

            if (number == 0)
            {
                monsterRarity = await context.MonstersRarities.FirstOrDefaultAsync(mr => mr.MonsterName == monster.Name && mr.Rarity == "Heroic");
                statAmplifier = monsterRarity.StatAmplifier;
                monster.ImagePath = monsterRarity.ImagePath.ToString();
            }
            else if (number > 0 && number < 5)
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
    }
}
