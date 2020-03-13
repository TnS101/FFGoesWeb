namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using System;

    public class ItemGenerator
    {
        private readonly Random rng;
        private readonly ValidatorHandler validatorHandler;

        public ItemGenerator()
        {
            this.rng = new Random();
            this.validatorHandler = new ValidatorHandler();
        }

        public Item Generate(Unit unit)
        {
            var stats = new int[] { };
            int fightingClassStatNumber = rng.Next(unit.Level, unit.Level + 5);
            int statNumber = rng.Next(0, 10);
            int slotNumber = rng.Next(0, 10);
            string fightingClassType = "";
            string weaponName = "";

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

            return validatorHandler.SlotCheck.Check(fightingClassStatNumber, slotNumber, stats, fightingClassStatNumber, fightingClassType, weaponName, validatorHandler);
        }
    }
}
