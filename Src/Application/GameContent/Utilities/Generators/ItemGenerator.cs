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
        public async Task Generate(Hero hero, IFFDbContext context, Monster monster, string zoneName, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var slotCheck = new SlotCheck();
            var stats = new List<int>();

            int fightingClassStatNumber = rng.Next(hero.Level, hero.Level + 5);
            int slotNumber = rng.Next(0, 10);
            int fightingClassNumber = rng.Next(0, 10);

            for (int i = 0; i < 8; i++)
            {
                int statNumber = rng.Next(0, 10);

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

            await slotCheck.Check(fightingClassNumber, slotNumber, stats, fightingClassStatNumber, context, hero, monster, zoneName, cancellationToken);
        }
    }
}
