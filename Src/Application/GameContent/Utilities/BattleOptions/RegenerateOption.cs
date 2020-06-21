namespace Application.GameContent.Utilities.BattleOptions
{
    using Domain.Contracts.Units;

    public class RegenerateOption
    {
        public void Regenerate(IUnit caster)
        {
            if (caster.CurrentHP <= caster.MaxHP - caster.CurrentHealthRegen)
            {
                caster.CurrentHP += caster.CurrentHealthRegen;
            }
            else
            {
                caster.CurrentHP = caster.MaxHP;
            }

            if (caster.CurrentMana <= caster.MaxMana - caster.CurrentManaRegen)
            {
                caster.CurrentMana += caster.CurrentManaRegen;
            }
            else
            {
                caster.CurrentMana = caster.MaxMana;
            }
        }
    }
}
