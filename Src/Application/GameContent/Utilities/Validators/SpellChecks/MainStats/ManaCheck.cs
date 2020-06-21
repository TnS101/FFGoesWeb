namespace Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using Domain.Contracts.Units;

    public class ManaCheck
    {
        public bool SpellManaCheck(IUnit caster, double manaRequirment)
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

        public bool EffectManaCheck(IUnit caster, double manaRequirment)
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
