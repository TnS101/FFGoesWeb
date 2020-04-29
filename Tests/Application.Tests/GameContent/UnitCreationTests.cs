using Application.GameContent.Utilities.Validators.UnitCreation;
using Application.Tests.Infrastructure;
using Common;
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
    public class UnitCreationTests : CommandTestBase
    {
        private readonly RaceCheck raceCheck;
        private readonly FightingClassCheck fightingClassCheck;

        public UnitCreationTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            QueryArrangeHelper.AddFightingClasses(context);
            this.raceCheck = new RaceCheck();
            this.fightingClassCheck = new FightingClassCheck();
        }

        [Fact]
        public void RaceSettingShouldBeHandledProperly()
        {
            var hero = this.context.Heroes.FirstOrDefault();
            this.RaceSet("Human", hero);

            this.raceCheck.Check(hero, "Human");

            this.RaceSet("Orc", hero);

            this.raceCheck.Check(hero, "Orc");

            this.RaceSet("Dwarf", hero);

            this.raceCheck.Check(hero, "Dwarf");

            this.RaceSet("Elf", hero);

            this.raceCheck.Check(hero, "Elf");

            this.RaceSet("Goblin", hero);

            this.raceCheck.Check(hero, "Goblin");

            this.RaceSet("Troll", hero);

            this.raceCheck.Check(hero, "Troll");

            hero.Race.ShouldBe(hero.Race);
        }

        private void RaceSet(string race, Hero hero)
        {
            hero.Race = race;

            context.Update(hero);
            context.SaveChanges();
        }

        [Fact]
        public async Task FightingClassSetShouldBeHandledProperly()
        {
            var hero = context.Heroes.FirstOrDefault();

            this.fightingClassCheck.Check(hero, "Warrior", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Hunter", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Mage", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Naturalist", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Paladin", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Priest", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Rogue", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Necroid", context).Status.ToString().ShouldBe(GConst.SuccessStatus);

            this.fightingClassCheck.Check(hero, "Shaman", context).Status.ToString().ShouldBe(GConst.SuccessStatus);
        }
        
    }
}
