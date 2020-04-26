namespace Application.GameContent.Utilities.Stats
{
    using Domain.Entities.Game.Units;

    public class StatsReset
    {
        public StatsReset()
        {
        }

        public void Reset(Hero hero)
        {
            hero.CurrentHP = hero.MaxHP;
            hero.CurrentMana = hero.CurrentMana;
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
