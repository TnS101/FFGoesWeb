namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Generators;
    using Application.GameContent.Utilities.Stats;
    using Domain.Entities.Game.Units;

    public class EndOption
    {
        public async Task End(Hero hero, Monster monster, string zoneName, IFFDbContext context, CancellationToken cancellationToken)
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

            new StatReset().Reset(hero);

            await new ItemGenerator().Generate(hero, context, monster, zoneName, cancellationToken);
        }

        private double EnemyCombinedStats(Monster monster)
        {
            return monster.MaxHP + monster.MaxMana + monster.AttackPower + monster.MagicPower
                + monster.ArmorValue + monster.ResistanceValue + monster.HealthRegen + monster.ManaRegen + monster.CritChance;
        }
    }
}
