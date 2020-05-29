namespace Application.GameContent.Utilities.Validators.UnitCreation
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;

    public class FightingClassCheck
    {
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

            new StatIncrement().Increment(fightingClass, hero);

            hero.FightingClassId = fightingClass.Id;

            return hero;
        }
    }
}
