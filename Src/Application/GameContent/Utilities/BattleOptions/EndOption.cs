namespace Application.GameContent.Utilities.BattleOptions
{
    using System;
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class EndOption
    {
        public void End(UnitFullViewModel hero, UnitFullViewModel enemy)
        {
            hero.XP += this.EnemyCombinedStats(enemy) / 18;
            hero.GoldAmount = (int)Math.Round(this.EnemyCombinedStats(enemy) / 30);

            // Stat reset
            hero.CurrentAttackPower = hero.AttackPower;
            hero.CurrentMagicPower = hero.MagicPower;
            hero.CurrentArmorValue = hero.ArmorValue;
            hero.CurrentRessistanceValue = hero.ResistanceValue;
            hero.CurrentHealthRegen = hero.HealthRegen;
            hero.CurrentManaRegen = hero.ManaRegen;
            hero.CurrentCritChance = hero.CritChance;
        }

        private double EnemyCombinedStats(UnitFullViewModel enemy)
        {
            return enemy.MaxHP + enemy.MaxMana + enemy.AttackPower + enemy.MagicPower
                + enemy.ArmorValue + enemy.ResistanceValue + enemy.HealthRegen + enemy.ManaRegen + enemy.CritChance;
        }
    }
}
