namespace Application.GameContent.Utilities.Validators.UnitCreation
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;

    public class FightingClassCheck
    {
        public async Task<Hero> Check(Hero hero, int fightingClassId, IFFDbContext context)
        {
            var fightingClass = await context.FightingClasses.FindAsync(fightingClassId);

            new StatIncrement().Increment(fightingClass, hero);

            hero.FightingClassId = fightingClass.Id;

            return hero;
        }
    }
}
