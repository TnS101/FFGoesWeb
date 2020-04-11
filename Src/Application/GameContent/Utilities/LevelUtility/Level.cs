namespace Application.GameContent.Utilities.LevelUtility
{
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;

    public class Level
    {
        public Level()
        {
        }

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
            hero.AttackPower += 2 * hero.Level;
            hero.ArmorValue += 1 * hero.Level;
            hero.CritChance += 0.05;
            hero.HealthRegen += 1.1;
            hero.MaxHP += 10 * hero.Level;
            hero.MagicPower += 2.75 * hero.Level;
            hero.MaxMana += 10 * hero.Level;
            hero.ManaRegen += 1.1 * hero.Level;
            hero.ResistanceValue += 1.3 * hero.Level;
            hero.Level++;

            // Stat Re-Set
            hero.CurrentHP = hero.MaxHP;
            hero.CurrentMana = hero.CurrentMana;
            hero.CurrentHealthRegen = hero.HealthRegen;
            hero.CurrentManaRegen = hero.ManaRegen;
            hero.CurrentMagicPower = hero.MagicPower;
            hero.CurrentAttackPower = hero.AttackPower;
            hero.CurrentArmorValue = hero.ArmorValue;
            hero.CurrentCritChance = hero.CritChance;
            hero.CurrentResistanceValue = hero.ResistanceValue;

            hero.XP -= hero.XPCap;
            hero.XPCap += hero.XPCap * 0.20;

            if (hero.XP < 0)
            {
                hero.XP = 0;
            }
        }
    }
}
