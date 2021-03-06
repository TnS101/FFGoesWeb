﻿namespace Application.GameContent.Utilities.LevelUtility
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;

    public class Level
    {
        public async Task Up(Hero hero, IFFDbContext context)
        {
            if (hero.Level == 10)
            {
                var user = await context.AppUsers.FindAsync(hero.UserId);

                hero.Mastery += 100;
                user.MasteryPoints += 100;
            }
            else if (hero.Level > 10)
            {
                var user = await context.AppUsers.FindAsync(hero.UserId);

                hero.Mastery += 15;
                user.MasteryPoints += 15;
            }

            // Increment
            hero.AttackPower += 2.2 * hero.Level;
            hero.ArmorValue += 1 * hero.Level;
            hero.CritChance += 0.05;
            hero.HealthRegen += 1;
            hero.MaxHP += 11.2 * hero.Level;
            hero.MagicPower += 2.4 * hero.Level;
            hero.MaxMana += 12.5 * hero.Level;
            hero.ManaRegen += 1 * hero.Level;
            hero.ResistanceValue += 1.2 * hero.Level;
            hero.Level++;

            // Stat Re-Set
            var statsReset = new StatReset();

            statsReset.HardReset(hero);

            hero.XP -= hero.XPCap;
            hero.XPCap += hero.XPCap * 0.20;

            if (hero.XP < 0)
            {
                hero.XP = 0;
            }
        }
    }
}
