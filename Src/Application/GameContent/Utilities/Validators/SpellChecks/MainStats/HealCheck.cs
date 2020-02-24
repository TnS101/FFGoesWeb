namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.MainStats
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class HealCheck
    {
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
