namespace Application.GameContent.Utilities.Validators.UnitCreation
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.FightingClassUtilites;
    using Domain.Base;

    public class FightingClassCheck
    {
        private readonly StatIncrement statIncrement;

        public FightingClassCheck()
        {
            this.statIncrement = new StatIncrement();
        }

        public async Task<Unit> Check(Unit hero, string fightingClassType, IFFDbContext context)
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

            this.statIncrement.Increment(fightingClass, hero);

            return hero;
        }
    }
}
