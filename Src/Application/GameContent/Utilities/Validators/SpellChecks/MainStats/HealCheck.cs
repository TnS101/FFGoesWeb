namespace Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using Domain.Base;

    public class HealCheck
    {
        public HealCheck()
        {
        }

        public void Check(Unit caster, Unit target, double manaRequirment, double healEffect, string spellName, ManaCheck manaCheck)
        {
            if (manaCheck.SpellManaCheck(caster, manaRequirment) == true)
            {
                if (target.CurrentHP <= target.MaxHP - healEffect)
                {
                    target.CurrentHP += healEffect;
                }
                else
                {
                    double overHeal = target.CurrentHP + healEffect - target.MaxHP;
                    target.CurrentHP += target.MaxHP - target.CurrentHP;
                }
            }
        }
    }
}
