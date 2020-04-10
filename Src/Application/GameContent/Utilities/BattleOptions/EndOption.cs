namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;

    public class EndOption
    {
        public async Task End(Hero hero, Monster monster, string zoneName, IFFDbContext context)
        {
            if (zoneName == "World")
            {
                hero.XP += this.EnemyCombinedStats(monster) / 18;
                hero.GoldAmount += (int)Math.Round(this.EnemyCombinedStats(monster) / 30);
            }
            else
            {
                hero.ProffesionXP += this.EnemyCombinedStats(monster) / 20;
            }

            if (hero.CurrentHP < hero.MaxHP)
            {
                await context.EnergyChanges.AddAsync(new EnergyChange
                {
                    HeroId = hero.Id,
                    Type = "Health",
                    LastChangedOn = DateTime.UtcNow,
                });
            }

            if (hero.MaxMana < hero.MaxMana)
            {
                await context.EnergyChanges.AddAsync(new EnergyChange
                {
                    HeroId = hero.Id,
                    Type = "Mana",
                    LastChangedOn = DateTime.UtcNow,
                });
            }

            // Stat reset
            hero.CurrentAttackPower = hero.AttackPower;
            hero.CurrentMagicPower = hero.MagicPower;
            hero.CurrentArmorValue = hero.ArmorValue;
            hero.CurrentResistanceValue = hero.ResistanceValue;
            hero.CurrentHealthRegen = hero.HealthRegen;
            hero.CurrentManaRegen = hero.ManaRegen;
            hero.CurrentCritChance = hero.CritChance;
        }

        private double EnemyCombinedStats(Monster monster)
        {
            return monster.MaxHP + monster.MaxMana + monster.AttackPower + monster.MagicPower
                + monster.ArmorValue + monster.ResistanceValue + monster.HealthRegen + monster.ManaRegen + monster.CritChance;
        }
    }
}
