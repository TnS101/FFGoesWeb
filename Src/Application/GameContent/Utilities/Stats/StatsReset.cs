namespace Application.GameContent.Utilities.Stats
{
    using Domain.Entities.Game.Units;

    public class StatsReset
    {
        public StatsReset()
        {
        }

        public void HardReset(Hero hero)
        {
            hero.CurrentHP = hero.MaxHP;
            hero.CurrentMana = hero.CurrentMana;

            this.Reset(hero);
        }

        public void Reset(Hero hero)
        {
            hero.CurrentHealthRegen = hero.HealthRegen;
            hero.CurrentManaRegen = hero.ManaRegen;
            hero.CurrentMagicPower = hero.MagicPower;
            hero.CurrentAttackPower = hero.AttackPower;
            hero.CurrentArmorValue = hero.ArmorValue;
            hero.CurrentCritChance = hero.CritChance;
            hero.CurrentResistanceValue = hero.ResistanceValue;
        }
    }
}
