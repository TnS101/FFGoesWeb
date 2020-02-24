namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class ManaCheck
    {
        public bool SpellManaCheck(Unit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment)
            {
                caster.CurrentMana -= manaRequirment;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EffectManaCheck(Unit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
