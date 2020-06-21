namespace Application.GameContent.Utilities.Stats
{
    using Domain.Contracts.Units;

    public class StatReset
    {
        public void HardReset(IUnit unit)
        {
            unit.CurrentHP = unit.MaxHP;
            unit.CurrentMana = unit.MaxMana;

            this.Reset(unit);
        }

        public void Reset(IUnit unit)
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
