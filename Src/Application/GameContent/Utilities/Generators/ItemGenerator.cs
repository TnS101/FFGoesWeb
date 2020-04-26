namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.Equipment;
    using Domain.Entities.Game.Units;

    public class ItemGenerator
    {
        private readonly Random rng;
        private readonly SlotCheck slotCheck;

        public ItemGenerator()
        {
            this.rng = new Random();
            this.slotCheck = new SlotCheck();
        }

        public async Task Generate(Hero hero, IFFDbContext context, Monster monster, string zoneName, CancellationToken cancellationToken)
        {
            var stats = new List<int>();
            int fightingClassStatNumber = this.rng.Next(hero.Level, hero.Level + 5);
            int slotNumber = this.rng.Next(0, 10);
            int fightingClassNumber = this.rng.Next(0,10);

            for (int i = 0; i < 8; i++)
            {
                int statNumber = this.rng.Next(0, 10);

                if (statNumber <= 6)
                {
                    stats.Add(hero.Level);
                }
                else if (statNumber > 6 && statNumber <= 8)
                {
                    stats.Add(hero.Level * 2);
                }
                else
                {
                    stats.Add(hero.Level * 3);
                }
            }

            await this.slotCheck.Check(fightingClassNumber, slotNumber, stats, fightingClassStatNumber, context, hero, monster, zoneName, cancellationToken);
        }
    }
}
