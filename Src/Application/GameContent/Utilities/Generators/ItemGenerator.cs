namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.Equipment;
    using Domain.Entities.Game.Units;

    public class ItemGenerator
    {
        private readonly Random rng;

        public ItemGenerator()
        {
            this.rng = new Random();
        }

        public async Task Generate(Hero hero, IFFDbContext context, Monster monster, string zoneName)
        {
            var stats = new int[] { };
            int fightingClassStatNumber = this.rng.Next(hero.Level, hero.Level + 5);
            int statNumber = this.rng.Next(0, 10);
            int slotNumber = this.rng.Next(0, 10);
            string fightingClassType = string.Empty;
            string weaponName = string.Empty;
            string imageURL = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                if (statNumber <= 6)
                {
                    stats[i] = hero.Level;
                }
                else if (statNumber > 6 && statNumber <= 8)
                {
                    stats[i] = hero.Level * 2;
                }
                else
                {
                    stats[i] = hero.Level * 3;
                }
            }

            var slotCheck = new SlotCheck();

            await slotCheck.Check(fightingClassStatNumber, slotNumber, stats, fightingClassStatNumber, fightingClassType, weaponName, context, hero, monster, zoneName);
        }
    }
}
