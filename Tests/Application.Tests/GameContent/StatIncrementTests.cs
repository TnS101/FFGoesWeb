using Application.GameContent.Utilities.FightingClassUtilites;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Application.Tests.GameContent
{
    public class StatIncrementTests : CommandTestBase
    {
        private readonly StatIncrement statIncrement;

        public StatIncrementTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            QueryArrangeHelper.AddMonsters(context);
            QueryArrangeHelper.AddFightingClasses(context);
            this.statIncrement = new StatIncrement();
        }

        [Fact]
        public void ShouldIncrement()
        {
            var hero = this.context.Heroes.FirstOrDefault();

            var fightingClass = this.context.FightingClasses.FirstOrDefault();

            this.statIncrement.Increment(fightingClass, hero);

            hero.ClassType.ShouldBe(fightingClass.Type);
            hero.MaxHP.ShouldBe(fightingClass.MaxHP);
            hero.CurrentHP.ShouldBe(fightingClass.MaxHP);
            hero.HealthRegen.ShouldBe(fightingClass.HealthRegen);
            hero.CurrentHealthRegen.ShouldBe(fightingClass.HealthRegen);
            hero.MaxMana.ShouldBe(fightingClass.MaxMana);
            hero.CurrentMana.ShouldBe(fightingClass.MaxMana);
            hero.ManaRegen.ShouldBe(fightingClass.ManaRegen);
            hero.CurrentManaRegen.ShouldBe(fightingClass.ManaRegen);
            hero.AttackPower.ShouldBe(fightingClass.AttackPower);
            hero.CurrentAttackPower.ShouldBe(fightingClass.AttackPower);
            hero.MagicPower.ShouldBe(fightingClass.MagicPower);
            hero.CurrentMagicPower.ShouldBe(fightingClass.MagicPower);
            hero.ArmorValue.ShouldBe(fightingClass.ArmorValue);
            hero.CurrentArmorValue.ShouldBe(fightingClass.ArmorValue);
            hero.ResistanceValue.ShouldBe(fightingClass.ResistanceValue);
            hero.CurrentResistanceValue.ShouldBe(fightingClass.ResistanceValue);
            hero.CritChance.ShouldBe(fightingClass.CritChance);
            hero.CurrentCritChance.ShouldBe(fightingClass.CritChance);
            hero.ImagePath.ShouldBe(fightingClass.ImagePath.ToString());
            hero.IconPath.ShouldBe(fightingClass.IconPath.ToString());
        }
    }
}
