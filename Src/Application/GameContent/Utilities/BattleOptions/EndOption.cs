namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class EndOption
    {
        public void End(UnitFullViewModel hero, UnitFullViewModel monster, string zoneName)
        {
            if (zoneName == "World")
            {
                hero.XP += this.EnemyCombinedStats(monster) / 18;
                hero.GoldAmount = (int)Math.Round(this.EnemyCombinedStats(monster) / 30);
            }
            else
            {
                hero.ProffesionXP += this.EnemyCombinedStats(monster) / 20;
                hero.GoldAmount = (int)Math.Round(this.EnemyCombinedStats(monster) / 33);
            }

            // Stat reset
            hero.CurrentAttackPower = hero.AttackPower;
            hero.CurrentMagicPower = hero.MagicPower;
            hero.CurrentArmorValue = hero.ArmorValue;
            hero.CurrentRessistanceValue = hero.ResistanceValue;
            hero.CurrentHealthRegen = hero.HealthRegen;
            hero.CurrentManaRegen = hero.ManaRegen;
            hero.CurrentCritChance = hero.CritChance;
        }

        private double EnemyCombinedStats(UnitFullViewModel monster)
        {
            return monster.MaxHP + monster.MaxMana + monster.AttackPower + monster.MagicPower
                + monster.ArmorValue + monster.ResistanceValue + monster.HealthRegen + monster.ManaRegen + monster.CritChance;
        }
    }
}
