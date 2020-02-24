namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class RegenerateOption
    {
        public void Regenerate(Unit caster)
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
