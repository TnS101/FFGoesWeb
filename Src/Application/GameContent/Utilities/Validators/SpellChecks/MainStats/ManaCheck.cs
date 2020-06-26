namespace Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using Domain.Contracts.Units;

    public class ManaCheck
    {
        public bool SpellManaCheck(IUnit caster, double manaRequirment)
        {
            var scaledManaRequirement = manaRequirment + ((caster.Level - 1) * 15);

            if (caster.CurrentMana >= scaledManaRequirement)
            {
                caster.CurrentMana -= scaledManaRequirement;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EffectManaCheck(IUnit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment + ((caster.Level - 1) * 15))
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
