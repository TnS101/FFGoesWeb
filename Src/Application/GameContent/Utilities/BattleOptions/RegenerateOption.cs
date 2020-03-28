namespace Application.GameContent.Utilities.BattleOptions
{
    using Application.GameCQ.Heroes.Queries.GetFullUnitQuery;

    public class RegenerateOption
    {
        public void Regenerate(UnitFullViewModel caster)
        {
            double hpRegen = caster.CurrentHealthRegen;
            double manaRegen = caster.CurrentManaRegen;

            if (caster.CurrentHP <= caster.MaxHP - hpRegen)
            {
                caster.CurrentHP += hpRegen;
            }
            else
            {
                caster.CurrentHP = caster.MaxHP;
            }

            if (caster.CurrentMana <= caster.MaxMana - manaRegen)
            {
                caster.CurrentMana += manaRegen;
            }
            else
            {
                caster.CurrentMana = caster.MaxMana;
            }
        }
    }
}
