using Application.GameContent.Utilities.BattleOptions;
using Application.GameContent.Utilities.Validators.Battle;
using Application.Tests.Infrastructure;
using Common;
using Domain.Base;
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
    public class TurnCheckTests : CommandTestBase
    {
        private readonly TurnCheck turnCheck;
        private AttackOption attackOption;
        private SpellCastOption spellCastOption;
        private DefendOption defendOption;

        public TurnCheckTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            QueryArrangeHelper.AddMonsters(context);
            this.turnCheck = new TurnCheck();
            QueryArrangeHelper.AddSpells(context);
        }

        [Fact]
        public async Task ShouldHandleTurnChecksProperly()
        {
            var hero = this.context.Heroes.FirstOrDefault();

            var monster = this.context.Monsters.FirstOrDefault(m => m.Name == "Bear");

            await this.Result(hero, monster, true);

            await this.Result(monster, hero, false);
        }

        private async Task Result(Unit unit1, Unit unit2, bool yourTurn)
        {
            if (yourTurn)
            {
                var check = await this.turnCheck.Check(unit1, unit2, true, context);

                check.ShouldBeFalse();
            }
            else
            {
                var check = await this.turnCheck.Check(unit2, unit1, true, context);

                var rng = new Random();

                var num = rng.Next(0, 2);

                if (num == 0 && unit2.CurrentMana >= unit2.CurrentMana * 0.15)
                {
                    this.spellCastOption = new SpellCastOption();

                    var spells = context.Spells.Where(s => s.ClassType == "Bear");

                    spells.Count().ShouldBe(4);

                    this.spellCastOption.SpellCast(unit2, unit1, string.Empty, context).Status.ToString().ShouldBe("Faulted");

                    unit2.CurrentHP.ShouldBe(unit2.CurrentHP);
                    unit1.CurrentHP.ShouldBe(unit1.CurrentHP);
                }
                else if (num == 1)
                {
                    this.attackOption = new AttackOption();
                    this.attackOption.Attack(unit2, unit1);

                    unit2.CurrentHP.ShouldBe(unit2.CurrentHP);
                    unit1.CurrentHP.ShouldBe(unit1.CurrentHP);
                }
                else
                {
                    this.defendOption = new DefendOption();

                    this.defendOption.Defend(unit2);

                    unit2.CurrentHP.ShouldBe(unit2.CurrentHP);
                    unit1.CurrentHP.ShouldBe(unit1.CurrentHP);
                }

                check.ShouldBeFalse();
            }
        }
    }
}
