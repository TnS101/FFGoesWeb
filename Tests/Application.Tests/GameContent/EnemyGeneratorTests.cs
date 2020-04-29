using Application.GameContent.Utilities.Generators;
using Application.Tests.Infrastructure;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameContent
{
    public class EnemyGeneratorTests : CommandTestBase
    {
        private readonly EnemyGenerator enemyGenerator;

        public EnemyGeneratorTests()
        {
            QueryArrangeHelper.AddMonsters(context);
            QueryArrangeHelper.AddMonsterRarities(context);
            this.enemyGenerator = new EnemyGenerator();
        }

        [Fact]
        public async Task ShouldGenerateMonster()
        {
            var bear = context.Monsters.Find(this.MonsterCreation());

            var bearMonster = await this.enemyGenerator.Generate(1, context, "World");

            this.StatCheck(bear, bearMonster);
        }

        private void StatCheck(Monster baseMonster, Monster monster)
        {
            int step = 1;

            monster.Id.ShouldBe(baseMonster.Id);
            monster.Name.ShouldBe(baseMonster.Name);
            monster.MaxHP.ShouldBe(baseMonster.MaxHP + (step * 11));
            monster.HealthRegen.ShouldBe(baseMonster.HealthRegen + (step * 1.15));
            monster.MaxMana.ShouldBe(baseMonster.MaxMana + (step * 11));
            monster.ManaRegen.ShouldBe(baseMonster.ManaRegen + (step * 1.1));
            monster.AttackPower.ShouldBe(baseMonster.AttackPower + (step * 2.22));
            monster.MagicPower.ShouldBe(baseMonster.MagicPower + (step * 2.5));
            monster.ArmorValue.ShouldBe(baseMonster.ArmorValue + (step * 1));
            monster.ResistanceValue.ShouldBe(baseMonster.ResistanceValue + (step * 1.2));
            monster.CritChance.ShouldBe(baseMonster.CritChance + (monster.Level * 0.04));
            monster.Type.ShouldBe(baseMonster.Type);
            monster.ImagePath.ShouldBe(baseMonster.ImagePath.ToString());

            monster.CurrentHP.ShouldBe(monster.MaxHP);
            monster.CurrentHealthRegen.ShouldBe(monster.HealthRegen);
            monster.CurrentMana.ShouldBe(monster.MaxMana);
            monster.CurrentManaRegen.ShouldBe(monster.ManaRegen);
            monster.CurrentAttackPower.ShouldBe(monster.AttackPower);
            monster.CurrentMagicPower.ShouldBe(monster.MagicPower);
            monster.CurrentArmorValue.ShouldBe(monster.ArmorValue);
            monster.CurrentResistanceValue.ShouldBe(monster.ResistanceValue);
            monster.CurrentCritChance.ShouldBe(monster.CritChance);
        }

        private int MonsterCreation()
        {
            var random = new Random();

            int enemyNumber = random.Next(0, 27);

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
