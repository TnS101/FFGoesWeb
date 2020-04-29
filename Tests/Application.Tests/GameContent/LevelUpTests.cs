using Application.GameContent.Utilities.LevelUtility;
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
    public class LevelUpTests : CommandTestBase
    {
        private Level level;

        public LevelUpTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            CommandArrangeHelper.GetUserId(context);
            this.level = new Level();
        }

        [Fact]
        public async Task ShouldLevelUp()
        {
            var appUser = this.context.AppUsers.FirstOrDefault();
            var hero = this.context.Heroes.FirstOrDefault();

            this.UpdateHeroLevel(hero, 10);
            await this.level.Up(hero, context);
            hero.Mastery.ShouldBe(100);
            appUser.MasteryPoints.ShouldBe(100);

            this.UpdateHeroLevel(hero, 11);
            await this.level.Up(hero, context);
            hero.Mastery.ShouldBe(115);
            appUser.MasteryPoints.ShouldBe(115);
        }

        public void UpdateHeroLevel(Hero hero, int level)
        {
            hero.Level = level;
            context.Heroes.Update(hero);
            context.SaveChanges();
        }
    }
}
