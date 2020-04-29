using Application.GameContent.Utilities.Stats;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameContent
{
    public class StatsResetTests : CommandTestBase
    {
        private readonly StatsReset statsReset;

        public StatsResetTests()
        {
            this.statsReset = new StatsReset();
            CommandArrangeHelper.GetHeroId(context);
        }

        [Fact]
        public void ShouldResetStats()
        {
            var hero = this.context.Heroes.FirstOrDefault();

            this.statsReset.HardReset(hero);

            hero.CurrentHP.ShouldBe(hero.MaxHP);
            hero.CurrentMana.ShouldBe(hero.CurrentMana);
            hero.CurrentHealthRegen.ShouldBe(hero.HealthRegen);
            hero.CurrentManaRegen.ShouldBe(hero.ManaRegen);
            hero.CurrentMagicPower.ShouldBe(hero.MagicPower);
            hero.CurrentAttackPower.ShouldBe(hero.AttackPower);
            hero.CurrentArmorValue.ShouldBe(hero.ArmorValue);
            hero.CurrentCritChance.ShouldBe(hero.CritChance);
            hero.CurrentResistanceValue = hero.ResistanceValue;

            this.statsReset.Reset(hero);
            hero.CurrentHealthRegen.ShouldBe(hero.HealthRegen);
            hero.CurrentManaRegen.ShouldBe(hero.ManaRegen);
            hero.CurrentMagicPower.ShouldBe(hero.MagicPower);
            hero.CurrentAttackPower.ShouldBe(hero.AttackPower);
            hero.CurrentArmorValue.ShouldBe(hero.ArmorValue);
            hero.CurrentCritChance.ShouldBe(hero.CritChance);
            hero.CurrentResistanceValue = hero.ResistanceValue;
        }
    }
}
