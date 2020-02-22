namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Generators
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Equipment;
    using System;

    public class ItemGenerator
    {
        private readonly FightingClassStatCheck fightingClassCheck = new FightingClassStatCheck();
        private readonly Random rng = new Random();
        private readonly ValidatorHandler validatorHandler = new ValidatorHandler();

        public ItemGenerator()
        {
        }

        public Item Generate(Unit player)
        {
            int fightingClassStatNumber = rng.Next(player.Level, player.Level + 5);
            int regularStatNumber = rng.Next(player.Level, player.Level + 2);
            int slotNumber = rng.Next(0, 10);
            string fightingClassType = "";
            string weaponName = "";

            return validatorHandler.SlotCheck.Check(fightingClassStatNumber, slotNumber, regularStatNumber, fightingClassStatNumber, fightingClassType, weaponName, validatorHandler);
        }
    }
}
