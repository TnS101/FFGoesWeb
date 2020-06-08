namespace Application.GameContent.Utilities.Stats
{
    using Domain.Base;

    public class StatReset
    {
        public void HardReset(Unit unit)
        {
            unit.CurrentHP = unit.MaxHP;
            unit.CurrentMana = unit.MaxMana;

            this.Reset(unit);
        }

        public void Reset(Unit unit)
        {
            unit.CurrentMagicPower = unit.MagicPower;
            unit.CurrentAttackPower = unit.AttackPower;
            unit.CurrentHealthRegen = unit.HealthRegen;
            unit.CurrentManaRegen = unit.ManaRegen;
            unit.CurrentArmorValue = unit.ArmorValue;
            unit.CurrentCritChance = unit.CritChance;
            unit.CurrentResistanceValue = unit.ResistanceValue;
        }
    }
}
