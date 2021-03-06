﻿namespace Application.GameContent.Utilities.Generators
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Validators.Equipment;
    using Domain.Entities.Game.Units;

    public class ItemGenerator
    {
        public async Task Generate(Hero hero, IFFDbContext context, string zoneName, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var itemHandler = new ItemHandler();
            var stats = new int[8];
            stats[0] = hero.Level == 1 ? rng.Next(hero.Level, hero.Level + 2) : rng.Next(hero.Level - 1, hero.Level + 3);

            int fightingClassStatNumber = rng.Next(hero.Level, hero.Level + 5);
            int slotNumber = rng.Next(16);
            int fightingClassNumber = rng.Next(9);

            for (int i = 1; i < 8; i++)
            {
                int statNumber = rng.Next(10);

                if (statNumber <= 6)
                {
                    stats[i] = stats[0];
                }
                else if (statNumber > 6 && statNumber <= 8)
                {
                    stats[i] = stats[0] + hero.Level;
                }
                else
                {
                    stats[i] = stats[0] + (hero.Level * 2);
                }
            }

            await itemHandler.Execute(fightingClassNumber, slotNumber, stats, fightingClassStatNumber, context, hero.Id, zoneName, cancellationToken);
        }
    }
}
