namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Generators
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.Equipment;
    using FinalFantasyTryoutGoesWeb.Domain.Entities;
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
