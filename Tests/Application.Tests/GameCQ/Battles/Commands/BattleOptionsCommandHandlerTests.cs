using Application.GameCQ.Battles.Commands.Update;
using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
using Application.Tests.Infrastructure;
using Common;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Battles.Commands
{
    public class BattleOptionsCommandHandlerTests : CommandTestBase
    {
        private BattleOptionsCommandHandler sut;

        public BattleOptionsCommandHandlerTests()
        {
            this.sut = new BattleOptionsCommandHandler(context);
            QueryArrangeHelper.AddMaterials(context);
            QueryArrangeHelper.AddArmors(context);
            QueryArrangeHelper.AddWeapons(context);
            QueryArrangeHelper.AddTrinkets(context);
            QueryArrangeHelper.AddTreasureKeys(context);
            QueryArrangeHelper.AddUsers(context);
            CommandArrangeHelper.GetHeroId(context);
        }

        [Fact]
        public async Task ShouldHandleBattleOptionsCorrectly()
        {
            var hero = this.context.Heroes.FirstOrDefault();

            var player = new UnitFullViewModel() { Id = "1" };

            var enemy = new Monster() { Type = "Beast", Id = 9 };

            enemy.CurrentHP = -0.00000000000001;
            var endResult = await this.Result(player, enemy, "Attack");
            endResult.ShouldBe(GConst.End);

            hero.XP += 100;
            this.context.Heroes.Update(hero);
            this.context.SaveChanges();
            enemy.CurrentHP = -0.00000000000001;

            var levelUpResult = await this.Result(player, enemy, "Attack");
            levelUpResult.ShouldBe(GConst.LevelUp);

            this.HeroHealthUpdate(hero, 0);

            var killedResult = await this.Result(player, enemy, "Attack");
            killedResult.ShouldBe(GConst.UnitKilled);

            enemy.CurrentHP = 100;
            this.HeroHealthUpdate(hero, 100);

            var battleResult = await this.Result(player, enemy, "Attack");
            battleResult.ShouldBe(GConst.BattleCommand);

            enemy.CurrentHP = 100;
            this.HeroHealthUpdate(hero, 100);

            var escapeResult = await this.Result(player, enemy, "Escape");
            escapeResult.ShouldBe(GConst.EscapeCommand);
        }

        private async Task<string> Result(UnitFullViewModel player, Monster enemy, string command)
        {
            return await this.sut.Handle(new BattleOptionsCommand { Player = player, Enemy = enemy, YourTurn = true, Command = command }, CancellationToken.None);
        }

        private void HeroHealthUpdate(Hero hero, double currentHP)
        {
            hero.CurrentHP = currentHP;
            this.context.Heroes.Update(hero);
            this.context.SaveChanges();
        }
    }
}
