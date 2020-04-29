using Application.GameContent.Utilities.BattleOptions;
using Application.Tests.Infrastructure;
using Domain.Base;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Application.Tests.GameContent
{
    public class AttackOptionTests : CommandTestBase
    {
        private readonly AttackOption attackOption;

        public AttackOptionTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            QueryArrangeHelper.AddMonsters(context);
            this.attackOption = new AttackOption();
        }

        [Fact]
        public void ShouldDealDamage()
        {
            var hero = this.context.Heroes.FirstOrDefault();
            var monster = this.context.Monsters.FirstOrDefault();

            this.UpdateValues(1, 10, 1, 10, hero, monster);

            hero.CurrentHP.ShouldBe(hero.CurrentHP);
            monster.CurrentHP.ShouldBe(monster.CurrentHP);

            this.UpdateValues(20, 20, 2, 2, hero, monster);

            this.attackOption.Attack(hero, monster);

            hero.CurrentArmorValue.ShouldBe(hero.CurrentArmorValue);

            this.UpdateValues(1, 1, 20, 20, hero, monster);
            this.attackOption.Attack(hero, monster);
            monster.CurrentArmorValue.ShouldBe(monster.CurrentArmorValue);

            this.UpdateValues(1, 1, 20, 20, hero, monster);
            this.attackOption.Attack(monster, hero);
            hero.CurrentHP.ShouldBe(hero.CurrentHP);
        }

        private void UpdateValues(double heroArmorValue, double heroAttackValue, double monsterArmorValue
            , double monsterAttackValue
            , Hero hero, Monster monster)
        {
            hero.CurrentArmorValue = heroArmorValue;
            hero.CurrentAttackPower = heroAttackValue;
            hero.CurrentAttackPower = this.CriticalHit(hero);

            monster.CurrentArmorValue = monsterArmorValue;
            monster.CurrentAttackPower = monsterAttackValue;
            monster.CurrentAttackPower = this.CriticalHit(monster);

            context.Heroes.Update(hero);
            context.Monsters.Update(monster);

            context.SaveChanges();
        }

        private double CriticalHit(Unit unit)
        {
            Random rng = new Random();

            int critNumber = rng.Next(0, 100);

            if (critNumber >= 0 && critNumber < Math.Floor(unit.CritChance))
            {
                return unit.CurrentAttackPower * 2;
            }
            else
            {
                return unit.CurrentAttackPower;
            }
        }
    }
}
