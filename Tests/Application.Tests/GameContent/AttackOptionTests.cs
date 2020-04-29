using Application.GameContent.Utilities.BattleOptions;
using Application.Tests.Infrastructure;
using Domain.Entities.Game.Units;
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


        }

        public void UpdateValues(double heroValue, double monsterValue, Hero hero, Monster monster)
        {
            hero.CurrentArmorValue = heroValue;
            hero.CurrentAttackPower = heroValue;

            monster.CurrentArmorValue = monsterValue;
            monster.CurrentAttackPower = monsterValue;
        }
    }
}
