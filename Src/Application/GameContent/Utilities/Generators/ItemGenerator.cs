namespace Application.GameContent.Utilities.Generators
{
    using System;
    using Application.GameContent.Handlers;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;
    using Domain.Base;

    public class ItemGenerator
    {
        private readonly Random rng;
        private readonly ValidatorHandler validatorHandler;

        public ItemGenerator()
        {
            this.rng = new Random();
            this.validatorHandler = new ValidatorHandler();
        }

        public Item Generate(UnitFullViewModel unit)
        {
            var stats = new int[] { };
            int fightingClassStatNumber = this.rng.Next(unit.Level, unit.Level + 5);
            int statNumber = this.rng.Next(0, 10);
            int slotNumber = this.rng.Next(0, 10);
            string fightingClassType = string.Empty;
            string weaponName = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                if (statNumber <= 6)
                {
                    stats[i] = unit.Level;
                }
                else if (statNumber > 6 && statNumber <= 8)
                {
                    stats[i] = unit.Level * 2;
                }
                else
                {
                    stats[i] = unit.Level * 3;
                }
            }

            return this.validatorHandler.SlotCheck.Check(fightingClassStatNumber, slotNumber, stats, fightingClassStatNumber, fightingClassType, weaponName, this.validatorHandler);
        }
    }
}
