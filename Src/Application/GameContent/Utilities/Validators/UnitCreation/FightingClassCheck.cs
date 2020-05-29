namespace Application.GameContent.Utilities.Validators.UnitCreation
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;
    using Domain.Entities.Game.Units.ManyToMany;
    using Microsoft.EntityFrameworkCore;

    public class FightingClassCheck
    {
        private readonly StatIncrement statIncrement;

        public FightingClassCheck()
        {
            this.statIncrement = new StatIncrement();
        }

        public async Task<Hero> Check(Hero hero, string fightingClassType, IFFDbContext context)
        {
            var fightingClassId = 0;

            if (fightingClassType == "Warrior")
            {
                fightingClassId = 9;
            }

            if (fightingClassType == "Hunter")
            {
                fightingClassId = 8;
            }

            if (fightingClassType == "Mage")
            {
                fightingClassId = 7;
            }

            if (fightingClassType == "Naturalist")
            {
                fightingClassId = 6;
            }

            if (fightingClassType == "Necroid")
            {
                fightingClassId = 5;
            }

            if (fightingClassType == "Paladin")
            {
                fightingClassId = 4;
            }

            if (fightingClassType == "Priest")
            {
                fightingClassId = 3;
            }

            if (fightingClassType == "Rogue")
            {
                fightingClassId = 2;
            }

            if (fightingClassType == "Shaman")
            {
                fightingClassId = 1;
            }

            var fightingClass = await context.FightingClasses.FindAsync(fightingClassId);

            var spells = await context.Spells.Where(s => s.ClassType == fightingClassType).ToListAsync();

            foreach (var spell in spells)
            {
                context.HeroesSpells.Add(new HeroSpell
                {
                    HeroId = hero.Id,
                    SpellId = spell.Id,
                });
            }

            this.statIncrement.Increment(fightingClass, hero);

            hero.FightingClassId = fightingClass.Id;

            return hero;
        }
    }
}
