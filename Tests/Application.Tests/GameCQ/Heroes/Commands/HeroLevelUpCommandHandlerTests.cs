using Application.GameCQ.Heroes.Commands.Update.HeroLevelUpCommand;
using Application.Tests.Infrastructure;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Heroes.Commands
{
    public class HeroLevelUpCommandHandlerTests : CommandTestBase
    {
        private readonly string heroId;
        private readonly HeroLevelUpCommandHandler sut;

        public HeroLevelUpCommandHandlerTests()
        {
            this.heroId = CommandArrangeHelper.GetHeroId(context);
            this.sut = new HeroLevelUpCommandHandler(context);
        }

        [Fact]
        public async Task ShouldUpdateStats()
        {
            var hero = this.context.Heroes.FirstOrDefault();

            await this.Result("Attack", hero);

            await this.Result("Health", hero);

            await this.Result("Mana", hero);

            await this.Result("Magic Power", hero);
        }

        private async Task Result(string stat, Hero hero)
        {
            await this.sut.Handle(new HeroLevelUpCommand { HeroId = this.heroId, StatPick = stat }, CancellationToken.None);

            if (stat == "Attack")
            {
                hero.AttackPower.ShouldBe(hero.AttackPower);
                hero.CurrentAttackPower.ShouldBe(hero.AttackPower);
            }
            else if (stat == "Health")
            {
                hero.MaxHP.ShouldBe(hero.MaxHP);
                hero.CurrentHP.ShouldBe(hero.MaxHP);
            }
            else if (stat == "Mana")
            {
                hero.MaxMana.ShouldBe(hero.MaxMana);
                hero.CurrentMana.ShouldBe(hero.MaxMana);
            }
            else if (stat == "Magic Power")
            {
                hero.MagicPower.ShouldBe(hero.MagicPower);
                hero.CurrentMagicPower.ShouldBe(hero.MagicPower);
            }

            this.context.Heroes.Update(hero);
            this.context.SaveChanges();
        }
    }
}
